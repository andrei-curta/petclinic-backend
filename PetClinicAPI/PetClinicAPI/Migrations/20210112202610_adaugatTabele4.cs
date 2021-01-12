using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinicAPI.Migrations
{
    public partial class adaugatTabele4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProdusId",
                table: "Specii",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Pret",
                table: "Servicii",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CategoriiProduse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriiProduse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategorieProdusId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produse_CategoriiProduse_CategorieProdusId",
                        column: x => x.CategorieProdusId,
                        principalTable: "CategoriiProduse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specii_ProdusId",
                table: "Specii",
                column: "ProdusId");

            migrationBuilder.CreateIndex(
                name: "IX_Produse_CategorieProdusId",
                table: "Produse",
                column: "CategorieProdusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specii_Produse_ProdusId",
                table: "Specii",
                column: "ProdusId",
                principalTable: "Produse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specii_Produse_ProdusId",
                table: "Specii");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "CategoriiProduse");

            migrationBuilder.DropIndex(
                name: "IX_Specii_ProdusId",
                table: "Specii");

            migrationBuilder.DropColumn(
                name: "ProdusId",
                table: "Specii");

            migrationBuilder.DropColumn(
                name: "Pret",
                table: "Servicii");
        }
    }
}
