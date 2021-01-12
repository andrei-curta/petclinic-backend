using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetClinicAPI.Models;

namespace PetClinicAPI.DataAccess
{
    public class PetClinicContext : DbContext
    {
        public PetClinicContext(DbContextOptions options) : base(options) { }
        public DbSet<Animal> Animale { get; set; }
        public DbSet<Medic> Medici { get; set; }
        public DbSet<Rasa> Rase { get; set; }
        public DbSet<Specie> Specii { get; set; }
        public DbSet<Utilizator> Utilizatori { get; set; }
    }
}
