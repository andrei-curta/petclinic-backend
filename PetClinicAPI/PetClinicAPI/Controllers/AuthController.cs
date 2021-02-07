using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetClinicAPI.DataAccess;
using PetClinicAPI.Models;

namespace PetClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PetClinicContext _context;
        private readonly UserManager<Utilizator> _userManager;

        public AuthController(PetClinicContext context, UserManager<Utilizator> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Register_DTO model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, "User already exists!");

            Utilizator user = new Utilizator()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = model.Username,
                UserName = model.Username,
                Nume = model.Nume,
                Preume = model.Prenume
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        Message = "User creation failed! Please check user details and try again. ",
                        Errors = result.Errors
                    });

            return Ok("User created successfully!");
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login(Login_DTO login)
        {
            if (await IsValidUsernameAndPassword(login.Username, login.Password))
            {
                var utilizator = _context.Utilizatori.First(u => u.UserName == login.Username);
                return new ObjectResult(utilizator);
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<bool> IsValidUsernameAndPassword(string username, string password)
        {
            var user = await _userManager.FindByEmailAsync(username);
            return await _userManager.CheckPasswordAsync(user, password);
        }

        private dynamic GenerateToken(string username)
        {
            var tokenExpiration = DateTime.Now.AddMinutes(30);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username),
                // new Claim(ClaimTypes.NameIdentifier, user.ID)
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp,
                    new DateTimeOffset(tokenExpiration).ToUnixTimeSeconds()
                        .ToString()) //TODO: schimbat expirarea tokenului
            };

            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(
                                "this is my custom Secret key for authnetication")), //TODO: schimbat secret key
                        SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims)
            );

            var outputToken = new
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                Username = username,
                expiration = tokenExpiration
            };

            return outputToken;
        }
    }
}