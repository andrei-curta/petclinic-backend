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
    public class ServiciuController : ControllerBase
    {
        private readonly PetClinicContext _context;

        public ServiciuController(PetClinicContext context)
        {
            _context = context;
        }

        // GET: api/Serviciu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Serviciu>>> GetServicii()
        {
            return await _context.Servicii.ToListAsync();
        }

        // GET: api/Serviciu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Serviciu>> GetServiciu(long id)
        {
            var serviciu = await _context.Servicii.FindAsync(id);

            if (serviciu == null)
            {
                return NotFound();
            }

            return serviciu;
        }

        // PUT: api/Serviciu/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiciu(long id, Serviciu serviciu)
        {
            if (id != serviciu.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviciu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciuExists(id))
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

        // POST: api/Serviciu
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Serviciu>> PostServiciu(Serviciu serviciu)
        {
            _context.Servicii.Add(serviciu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiciu", new { id = serviciu.Id }, serviciu);
        }

        // DELETE: api/Serviciu/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Serviciu>> DeleteServiciu(long id)
        {
            var serviciu = await _context.Servicii.FindAsync(id);
            if (serviciu == null)
            {
                return NotFound();
            }

            _context.Servicii.Remove(serviciu);
            await _context.SaveChangesAsync();

            return serviciu;
        }

        private bool ServiciuExists(long id)
        {
            return _context.Servicii.Any(e => e.Id == id);
        }
    }
}
