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
    public class RasaController : ControllerBase
    {
        private readonly PetClinicContext _context;

        public RasaController(PetClinicContext context)
        {
            _context = context;
        }

        // GET: api/Rasa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rasa>>> GetRase()
        {
            return await _context.Rase.ToListAsync();
        }

        // GET: api/Rasa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rasa>> GetRasa(long id)
        {
            var rasa = await _context.Rase.FindAsync(id);

            if (rasa == null)
            {
                return NotFound();
            }

            return rasa;
        }

        // PUT: api/Rasa/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRasa(long id, Rasa rasa)
        {
            if (id != rasa.Id)
            {
                return BadRequest();
            }

            _context.Entry(rasa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RasaExists(id))
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

        // POST: api/Rasa
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rasa>> PostRasa(Rasa rasa)
        {
            _context.Rase.Add(rasa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRasa", new { id = rasa.Id }, rasa);
        }

        // DELETE: api/Rasa/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rasa>> DeleteRasa(long id)
        {
            var rasa = await _context.Rase.FindAsync(id);
            if (rasa == null)
            {
                return NotFound();
            }

            _context.Rase.Remove(rasa);
            await _context.SaveChangesAsync();

            return rasa;
        }

        private bool RasaExists(long id)
        {
            return _context.Rase.Any(e => e.Id == id);
        }
    }
}
