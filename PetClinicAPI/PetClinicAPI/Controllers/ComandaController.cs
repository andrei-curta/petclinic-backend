﻿using System;
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
    public class ComandaController : ControllerBase
    {
        private readonly PetClinicContext _context;

        public ComandaController(PetClinicContext context)
        {
            _context = context;
        }

        // GET: api/Comanda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comanda>>> GetComenzi()
        {
            return await _context.Comenzi.ToListAsync();
        }

        // GET: api/Comanda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comanda>> GetComanda(long id)
        {
            var comanda = await _context.Comenzi.FindAsync(id);

            if (comanda == null)
            {
                return NotFound();
            }

            return comanda;
        }

        // PUT: api/Comanda/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComanda(long id, Comanda comanda)
        {
            if (id != comanda.Id)
            {
                return BadRequest();
            }

            _context.Entry(comanda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComandaExists(id))
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

        // POST: api/Comanda
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Comanda>> PostComanda(Comanda comanda)
        {
            _context.Comenzi.Add(comanda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComanda", new { id = comanda.Id }, comanda);
        }

        // DELETE: api/Comanda/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comanda>> DeleteComanda(long id)
        {
            var comanda = await _context.Comenzi.FindAsync(id);
            if (comanda == null)
            {
                return NotFound();
            }

            _context.Comenzi.Remove(comanda);
            await _context.SaveChangesAsync();

            return comanda;
        }

        private bool ComandaExists(long id)
        {
            return _context.Comenzi.Any(e => e.Id == id);
        }
    }
}
