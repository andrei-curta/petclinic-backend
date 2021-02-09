using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinicAPI.Migrations
{
    public partial class CategorieProdusUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CategoriiProduse_Nume",
                table: "CategoriiProduse",
                column: "Nume",
                unique: true,
                filter: "[Nume] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoriiProduse_Nume",
                table: "CategoriiProduse");
        }
    }
}
