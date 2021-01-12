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
    public class MedicController : ControllerBase
    {
        private readonly PetClinicContext _context;

        public MedicController(PetClinicContext context)
        {
            _context = context;
        }

        // GET: api/Medic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medic>>> GetMedici()
        {
            return await _context.Medici.ToListAsync();
        }

        // GET: api/Medic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medic>> GetMedic(long id)
        {
            var medic = await _context.Medici.FindAsync(id);

            if (medic == null)
            {
                return NotFound();
            }

            return medic;
        }

        // PUT: api/Medic/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedic(long id, Medic medic)
        {
            if (id != medic.Id)
            {
                return BadRequest();
            }

            _context.Entry(medic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicExists(id))
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

        // POST: api/Medic
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Medic>> PostMedic(Medic medic)
        {
            _context.Medici.Add(medic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedic", new { id = medic.Id }, medic);
        }

        // DELETE: api/Medic/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Medic>> DeleteMedic(long id)
        {
            var medic = await _context.Medici.FindAsync(id);
            if (medic == null)
            {
                return NotFound();
            }

            _context.Medici.Remove(medic);
            await _context.SaveChangesAsync();

            return medic;
        }

        private bool MedicExists(long id)
        {
            return _context.Medici.Any(e => e.Id == id);
        }
    }
}
