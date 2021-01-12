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
    public class StatusProgramareController : ControllerBase
    {
        private readonly PetClinicContext _context;

        public StatusProgramareController(PetClinicContext context)
        {
            _context = context;
        }

        // GET: api/StatusProgramare
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusProgramare>>> GetStatusuriProgramari()
        {
            return await _context.StatusuriProgramari.ToListAsync();
        }

        // GET: api/StatusProgramare/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusProgramare>> GetStatusProgramare(long id)
        {
            var statusProgramare = await _context.StatusuriProgramari.FindAsync(id);

            if (statusProgramare == null)
            {
                return NotFound();
            }

            return statusProgramare;
        }

        // PUT: api/StatusProgramare/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusProgramare(long id, StatusProgramare statusProgramare)
        {
            if (id != statusProgramare.Id)
            {
                return BadRequest();
            }

            _context.Entry(statusProgramare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusProgramareExists(id))
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

        // POST: api/StatusProgramare
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StatusProgramare>> PostStatusProgramare(StatusProgramare statusProgramare)
        {
            _context.StatusuriProgramari.Add(statusProgramare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusProgramare", new { id = statusProgramare.Id }, statusProgramare);
        }

        // DELETE: api/StatusProgramare/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusProgramare>> DeleteStatusProgramare(long id)
        {
            var statusProgramare = await _context.StatusuriProgramari.FindAsync(id);
            if (statusProgramare == null)
            {
                return NotFound();
            }

            _context.StatusuriProgramari.Remove(statusProgramare);
            await _context.SaveChangesAsync();

            return statusProgramare;
        }

        private bool StatusProgramareExists(long id)
        {
            return _context.StatusuriProgramari.Any(e => e.Id == id);
        }
    }
}
