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
    public class SpecieController : ControllerBase
    {
        private readonly PetClinicContext _context;

        public SpecieController(PetClinicContext context)
        {
            _context = context;
        }

        // GET: api/Specie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specie>>> GetSpecii()
        {
            return await _context.Specii.ToListAsync();
        }

        // GET: api/Specie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Specie>> GetSpecie(long id)
        {
            var specie = await _context.Specii.FindAsync(id);

            if (specie == null)
            {
                return NotFound();
            }

            return specie;
        }

        // PUT: api/Specie/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecie(long id, Specie specie)
        {
            if (id != specie.Id)
            {
                return BadRequest();
            }

            _context.Entry(specie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecieExists(id))
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

        // POST: api/Specie
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Specie>> PostSpecie(Specie specie)
        {
            _context.Specii.Add(specie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecie", new { id = specie.Id }, specie);
        }

        // DELETE: api/Specie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Specie>> DeleteSpecie(long id)
        {
            var specie = await _context.Specii.FindAsync(id);
            if (specie == null)
            {
                return NotFound();
            }

            _context.Specii.Remove(specie);
            await _context.SaveChangesAsync();

            return specie;
        }

        private bool SpecieExists(long id)
        {
            return _context.Specii.Any(e => e.Id == id);
        }
    }
}
