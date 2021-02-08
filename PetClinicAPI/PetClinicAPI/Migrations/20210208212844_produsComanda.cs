using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinicAPI.Migrations
{
    public partial class produsComanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_Comenzi_ComandaId",
                table: "Produse");

            migrationBuilder.DropIndex(
                name: "IX_Produse_ComandaId",
                table: "Produse");

            migrationBuilder.DropColumn(
                name: "ComandaId",
                table: "Produse");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Comenzi",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ProdusComanda",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantitate = table.Column<long>(type: "bigint", nullable: false),
                    ProdusId = table.Column<long>(type: "bigint", nullable: false),
                    ComandaId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdusComanda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdusComanda_Comenzi_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comenzi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdusComanda_Produse_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdusComanda_ComandaId",
                table: "ProdusComanda",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdusComanda_ProdusId",
                table: "ProdusComanda",
                column: "ProdusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdusComanda");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Comenzi");

            migrationBuilder.AddColumn<long>(
                name: "ComandaId",
                table: "Produse",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produse_ComandaId",
                table: "Produse",
                column: "ComandaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_Comenzi_ComandaId",
                table: "Produse",
                column: "ComandaId",
                principalTable: "Comenzi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
