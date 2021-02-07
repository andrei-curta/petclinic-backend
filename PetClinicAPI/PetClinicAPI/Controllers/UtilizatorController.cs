using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetClinicAPI.DataAccess;
using PetClinicAPI.Models;

namespace PetClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizatorController : ControllerBase
    {
        private readonly PetClinicContext _context;

        public UtilizatorController(PetClinicContext context)
        {
            _context = context;
        }

        // GET: api/Utilizator
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilizator>>> GetUtilizatori()
        {
            return await _context.Utilizatori.ToListAsync();
        }

        // GET: api/Utilizator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizator>> GetUtilizator(string id)
        {
            var utilizator = await _context.Utilizatori.FindAsync(id);

            if (utilizator == null)
            {
                return NotFound();
            }

            return utilizator;
        }
        
        // PUT: api/Utilizator/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilizator(string id, Utilizator utilizator)
        {
            if (id != utilizator.Id)
            {
                return BadRequest();
            }

            _context.Entry(utilizator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Utilizator
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Utilizator>> PostUtilizator(Utilizator utilizator)
        {
            _context.Utilizatori.Add(utilizator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilizator", new { id = utilizator.Id }, utilizator);
        }

        // DELETE: api/Utilizator/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Utilizator>> DeleteUtilizator(long id)
        {
            var utilizator = await _context.Utilizatori.FindAsync(id);
            if (utilizator == null)
            {
                return NotFound();
            }

            _context.Utilizatori.Remove(utilizator);
            await _context.SaveChangesAsync();

            return utilizator;
        }

        private bool UtilizatorExists(string id)
        {
            return _context.Utilizatori.Any(e => e.Id == id);
        }
    }
}
