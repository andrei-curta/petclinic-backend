using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinicAPI.Migrations
{
    public partial class statusProgramareUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StatusuriProgramari_Nume",
                table: "StatusuriProgramari",
                column: "Nume",
                unique: true,
                filter: "[Nume] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StatusuriProgramari_Nume",
                table: "StatusuriProgramari");
        }
    }
}
