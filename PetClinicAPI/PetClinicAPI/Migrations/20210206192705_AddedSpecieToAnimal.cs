using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinicAPI.Migrations
{
    public partial class AddedSpecieToAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RasaId",
                table: "Animale",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animale_RasaId",
                table: "Animale",
                column: "RasaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animale_Rase_RasaId",
                table: "Animale",
                column: "RasaId",
                principalTable: "Rase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animale_Rase_RasaId",
                table: "Animale");

            migrationBuilder.DropIndex(
                name: "IX_Animale_RasaId",
                table: "Animale");

            migrationBuilder.DropColumn(
                name: "RasaId",
                table: "Animale");
        }
    }
}
