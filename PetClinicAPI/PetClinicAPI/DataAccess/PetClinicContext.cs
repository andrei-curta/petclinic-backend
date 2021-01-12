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
        public DbSet<Pet> Pets { get; set; }
    }
}
