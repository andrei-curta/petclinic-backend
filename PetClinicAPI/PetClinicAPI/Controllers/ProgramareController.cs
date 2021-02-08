using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetClinicAPI.DataAccess;
using PetClinicAPI.Models;
using PetClinicAPI.Models.DTO;

namespace PetClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramareController : ControllerBase
    {
        private readonly PetClinicContext _context;

        public ProgramareController(PetClinicContext context)
        {
            _context = context;
        }

        // GET: api/Programare
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programare>>> GetProgramari()
        {
            return await _context.Programari.Include("Servicii").ToListAsync();
        }

        [HttpGet("userId={userId}")]
        public async Task<ActionResult<IEnumerable<Programare>>> GetProgramareByUtilizator(string userId)
        {
            return await _context.Programari.Include("Servicii").Where(p => p.Animal.StapanId == userId).ToListAsync();
        }

        // GET: api/Programare/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Programare>> GetProgramare(long id)
        {
            var programare = await _context.Programari.FindAsync(id);

            if (programare == null)
            {
                return NotFound();
            }

            return programare;
        }

        // PUT: api/Programare/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramare(long id, Programare programare)
        {
            if (id != programare.Id)
            {
                return BadRequest();
            }

            _context.Entry(programare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramareExists(id))
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

        // POST: api/Programare
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Programare>> PostProgramare(ProgramarePost_DTO programareDto)
        {
            Programare programare = new Programare();
            programare.AnimalId = programareDto.AnimalId;
            programare.MedicId = programareDto.MedicId;
            programare.DataConsultatie = programareDto.DataConsultatie;
            programare.Servicii =
                await _context.Servicii.Where(s => programareDto.ServiciiId.Contains(s.Id)).ToListAsync();

            _context.Programari.Add(programare);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            return CreatedAtAction("GetProgramare", new {id = programare.Id}, programare);
        }

        // DELETE: api/Programare/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Programare>> DeleteProgramare(long id)
        {
            var programare = await _context.Programari.FindAsync(id);
            if (programare == null)
            {
                return NotFound();
            }

            _context.Programari.Remove(programare);
            await _context.SaveChangesAsync();

            return programare;
        }

        private bool ProgramareExists(long id)
        {
            return _context.Programari.Any(e => e.Id == id);
        }
    }
}