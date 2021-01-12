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
    public class CategorieProdusController : ControllerBase
    {
        private readonly PetClinicContext _context;

        public CategorieProdusController(PetClinicContext context)
        {
            _context = context;
        }

        // GET: api/CategorieProdus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategorieProdus>>> GetCategoriiProduse()
        {
            return await _context.CategoriiProduse.ToListAsync();
        }

        // GET: api/CategorieProdus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategorieProdus>> GetCategorieProdus(long id)
        {
            var categorieProdus = await _context.CategoriiProduse.FindAsync(id);

            if (categorieProdus == null)
            {
                return NotFound();
            }

            return categorieProdus;
        }

        // PUT: api/CategorieProdus/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorieProdus(long id, CategorieProdus categorieProdus)
        {
            if (id != categorieProdus.Id)
            {
                return BadRequest();
            }

            _context.Entry(categorieProdus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieProdusExists(id))
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

        // POST: api/CategorieProdus
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CategorieProdus>> PostCategorieProdus(CategorieProdus categorieProdus)
        {
            _context.CategoriiProduse.Add(categorieProdus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorieProdus", new { id = categorieProdus.Id }, categorieProdus);
        }

        // DELETE: api/CategorieProdus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategorieProdus>> DeleteCategorieProdus(long id)
        {
            var categorieProdus = await _context.CategoriiProduse.FindAsync(id);
            if (categorieProdus == null)
            {
                return NotFound();
            }

            _context.CategoriiProduse.Remove(categorieProdus);
            await _context.SaveChangesAsync();

            return categorieProdus;
        }

        private bool CategorieProdusExists(long id)
        {
            return _context.CategoriiProduse.Any(e => e.Id == id);
        }
    }
}
