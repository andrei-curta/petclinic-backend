using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinicAPI.Migrations
{
    public partial class adaugatTabele3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusuriProgramari",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusuriProgramari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Programari",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<long>(type: "bigint", nullable: true),
                    DataConsultatie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicId = table.Column<long>(type: "bigint", nullable: true),
                    Observatii = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StatusProgramareId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programari_Animale_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programari_Medici_MedicId",
                        column: x => x.MedicId,
                        principalTable: "Medici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Programari_StatusuriProgramari_StatusProgramareId",
                        column: x => x.StatusProgramareId,
                        principalTable: "StatusuriProgramari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicii",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProgramareId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicii_Programari_ProgramareId",
                        column: x => x.ProgramareId,
                        principalTable: "Programari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programari_AnimalId",
                table: "Programari",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Programari_MedicId",
                table: "Programari",
                column: "MedicId");

            migrationBuilder.CreateIndex(
                name: "IX_Programari_StatusProgramareId",
                table: "Programari",
                column: "StatusProgramareId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicii_ProgramareId",
                table: "Servicii",
                column: "ProgramareId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicii");

            migrationBuilder.DropTable(
                name: "Programari");

            migrationBuilder.DropTable(
                name: "StatusuriProgramari");
        }
    }
}
