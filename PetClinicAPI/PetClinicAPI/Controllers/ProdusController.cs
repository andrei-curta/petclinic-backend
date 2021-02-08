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
    public class ProdusController : ControllerBase
    {
        private readonly PetClinicContext _context;

        public ProdusController(PetClinicContext context)
        {
            _context = context;
        }

        // GET: api/Produs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produs>>> GetProduse()
        {
            return await _context.Produse.ToListAsync();
        }

        // GET: api/Produs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produs>> GetProdus(long id)
        {
            var produs = await _context.Produse.FindAsync(id);

            if (produs == null)
            {
                return NotFound();
            }

            return produs;
        }

        // PUT: api/Produs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdus(long id, Produs produs)
        {
            if (id != produs.Id)
            {
                return BadRequest();
            }

            _context.Entry(produs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdusExists(id))
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

        // POST: api/Produs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Produs>> PostProdus(ProdusPost_DTO produsDto)
        {
            Produs produs = new Produs();
            produs.Nume = produsDto.Nume;
            produs.Pret = produsDto.Pret;
            produs.CategorieProdusId = produsDto.CategorieProdusId;
            produs.SpeciiTinta =
                await _context.Specii.Where(s => produsDto.SpeciiTintaId.Contains(s.Id)).ToListAsync();

            _context.Produse.Add(produs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdus", new {id = produs.Id}, produs);
        }

        // DELETE: api/Produs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Produs>> DeleteProdus(long id)
        {
            var produs = await _context.Produse.FindAsync(id);
            if (produs == null)
            {
                return NotFound();
            }

            _context.Produse.Remove(produs);
            await _context.SaveChangesAsync();

            return produs;
        }

        private bool ProdusExists(long id)
        {
            return _context.Produse.Any(e => e.Id == id);
        }
    }
}