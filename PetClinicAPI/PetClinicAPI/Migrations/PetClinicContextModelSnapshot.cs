﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetClinicAPI.DataAccess;

namespace PetClinicAPI.Migrations
{
    [DbContext(typeof(PetClinicContext))]
    partial class PetClinicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("PetClinicAPI.Models.Animal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Nume")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<long?>("StapanId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StapanId");

                    b.ToTable("Animale");
                });

            modelBuilder.Entity("PetClinicAPI.Models.CategorieProdus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Nume")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("CategoriiProduse");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Medic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("CNP")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Nume")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Preume")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Medici");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Produs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("CategorieProdusId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nume")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategorieProdusId");

                    b.ToTable("Produse");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Programare", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long?>("AnimalId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataConsultatie")
                        .HasColumnType("datetime2");

                    b.Property<long?>("MedicId")
                        .HasColumnType("bigint");

                    b.Property<string>("Observatii")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<long?>("StatusProgramareId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("MedicId");

                    b.HasIndex("StatusProgramareId");

                    b.ToTable("Programari");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Rasa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Nume")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<long?>("SpecieId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SpecieId");

                    b.ToTable("Rase");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Serviciu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Nume")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(10,2)");

                    b.Property<long?>("ProgramareId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProgramareId");

                    b.ToTable("Servicii");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Specie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Nume")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<long?>("ProdusId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProdusId");

                    b.ToTable("Specii");
                });

            modelBuilder.Entity("PetClinicAPI.Models.StatusProgramare", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Nume")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("StatusuriProgramari");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Utilizator", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CNP")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Preume")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Utilizatori");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Animal", b =>
                {
                    b.HasOne("PetClinicAPI.Models.Utilizator", "Stapan")
                        .WithMany()
                        .HasForeignKey("StapanId");

                    b.Navigation("Stapan");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Produs", b =>
                {
                    b.HasOne("PetClinicAPI.Models.CategorieProdus", "CategorieProdus")
                        .WithMany()
                        .HasForeignKey("CategorieProdusId");

                    b.Navigation("CategorieProdus");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Programare", b =>
                {
                    b.HasOne("PetClinicAPI.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId");

                    b.HasOne("PetClinicAPI.Models.Medic", "Medic")
                        .WithMany()
                        .HasForeignKey("MedicId");

                    b.HasOne("PetClinicAPI.Models.StatusProgramare", "StatusProgramare")
                        .WithMany()
                        .HasForeignKey("StatusProgramareId");

                    b.Navigation("Animal");

                    b.Navigation("Medic");

                    b.Navigation("StatusProgramare");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Rasa", b =>
                {
                    b.HasOne("PetClinicAPI.Models.Specie", "Specie")
                        .WithMany("Rase")
                        .HasForeignKey("SpecieId");

                    b.Navigation("Specie");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Serviciu", b =>
                {
                    b.HasOne("PetClinicAPI.Models.Programare", null)
                        .WithMany("Servicii")
                        .HasForeignKey("ProgramareId");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Specie", b =>
                {
                    b.HasOne("PetClinicAPI.Models.Produs", null)
                        .WithMany("SpeciiTinta")
                        .HasForeignKey("ProdusId");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Produs", b =>
                {
                    b.Navigation("SpeciiTinta");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Programare", b =>
                {
                    b.Navigation("Servicii");
                });

            modelBuilder.Entity("PetClinicAPI.Models.Specie", b =>
                {
                    b.Navigation("Rase");
                });
#pragma warning restore 612, 618
        }
    }
}
