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
    public class AnimalController : ControllerBase
    {
        private readonly PetClinicContext _context;

        public AnimalController(PetClinicContext context)
        {
            _context = context;
        }

        // GET: api/Animal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimale()
        {
            return await _context.Animale.ToListAsync();
        }

        // GET: api/Animal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(long id)
        {
            var animal = await _context.Animale.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        // PUT: api/Animal/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(long id, Animal animal)
        {
            if (id != animal.Id)
            {
                return BadRequest();
            }

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
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

        // POST: api/Animal
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
            _context.Animale.Add(animal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimal", new { id = animal.Id }, animal);
        }

        // DELETE: api/Animal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Animal>> DeleteAnimal(long id)
        {
            var animal = await _context.Animale.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animale.Remove(animal);
            await _context.SaveChangesAsync();

            return animal;
        }

        private bool AnimalExists(long id)
        {
            return _context.Animale.Any(e => e.Id == id);
        }
    }
}
