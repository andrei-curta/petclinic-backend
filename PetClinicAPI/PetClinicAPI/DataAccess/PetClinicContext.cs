using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PetClinicAPI.Models;

namespace PetClinicAPI.DataAccess
{
    public class PetClinicContext : DbContext
    {
        public PetClinicContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Animal> Animale { get; set; }
        public DbSet<Medic> Medici { get; set; }
        public DbSet<Rasa> Rase { get; set; }
        public DbSet<Specie> Specii { get; set; }
        public DbSet<Utilizator> Utilizatori { get; set; }
        public DbSet<Programare> Programari { get; set; }
        public DbSet<Serviciu> Servicii { get; set; }
        public DbSet<StatusProgramare> StatusuriProgramari { get; set; }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<CategorieProdus> CategoriiProduse { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StatusProgramare>()
                .HasIndex(u => u.Nume)
                .IsUnique();

            builder.Entity<StatusProgramare>()
                .Property(p => p.Nume)
                .IsRequired();

            builder.Entity<CategorieProdus>()
                .HasIndex(u => u.Nume)
                .IsUnique();

            builder.Entity<CategorieProdus>()
                .Property(p => p.Nume)
                .IsRequired();

            builder.Entity<Medic>()
                .Property(p => p.Nume)
                .IsRequired();

            builder.Entity<Medic>()
                .Property(p => p.Preume)
                .IsRequired();
        }
    }

    public class PetClinicFactory : IDesignTimeDbContextFactory<PetClinicContext>
    {
        public PetClinicContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PetClinicContext>();
            optionsBuilder.UseSqlServer(
                "Server=tcp:andreicurta.database.windows.net,1433;Initial Catalog=petshop;Persist Security Info=False;User ID=andrei.curta;Password=ParolaAzure1q2w3e;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new PetClinicContext(optionsBuilder.Options);
        }
    }
}