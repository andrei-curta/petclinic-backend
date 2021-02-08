using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinicAPI.Migrations
{
    public partial class updateComanda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produse_CategoriiProduse_CategorieProdusId",
                table: "Produse");

            migrationBuilder.DropForeignKey(
                name: "FK_Programari_Animale_AnimalId",
                table: "Programari");

            migrationBuilder.DropForeignKey(
                name: "FK_Programari_Medici_MedicId",
                table: "Programari");

            migrationBuilder.DropColumn(
                name: "IdUtilizator",
                table: "Utilizatori");

            migrationBuilder.AlterColumn<long>(
                name: "MedicId",
                table: "Programari",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AnimalId",
                table: "Programari",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CategorieProdusId",
                table: "Produse",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UtilizatorId",
                table: "Comenzi",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_UtilizatorId",
                table: "Comenzi",
                column: "UtilizatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comenzi_Utilizatori_UtilizatorId",
                table: "Comenzi",
                column: "UtilizatorId",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_CategoriiProduse_CategorieProdusId",
                table: "Produse",
                column: "CategorieProdusId",
                principalTable: "CategoriiProduse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programari_Animale_AnimalId",
                table: "Programari",
                column: "AnimalId",
                principalTable: "Animale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Programari_Medici_MedicId",
                table: "Programari",
                column: "MedicId",
                principalTable: "Medici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comenzi_Utilizatori_UtilizatorId",
                table: "Comenzi");

            migrationBuilder.DropForeignKey(
                name: "FK_Produse_CategoriiProduse_CategorieProdusId",
                table: "Produse");

            migrationBuilder.DropForeignKey(
                name: "FK_Programari_Animale_AnimalId",
                table: "Programari");

            migrationBuilder.DropForeignKey(
                name: "FK_Programari_Medici_MedicId",
                table: "Programari");

            migrationBuilder.DropIndex(
                name: "IX_Comenzi_UtilizatorId",
                table: "Comenzi");

            migrationBuilder.DropColumn(
                name: "UtilizatorId",
                table: "Comenzi");

            migrationBuilder.AddColumn<long>(
                name: "IdUtilizator",
                table: "Utilizatori",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "MedicId",
                table: "Programari",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AnimalId",
                table: "Programari",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CategorieProdusId",
                table: "Produse",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Produse_CategoriiProduse_CategorieProdusId",
                table: "Produse",
                column: "CategorieProdusId",
                principalTable: "CategoriiProduse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programari_Animale_AnimalId",
                table: "Programari",
                column: "AnimalId",
                principalTable: "Animale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Programari_Medici_MedicId",
                table: "Programari",
                column: "MedicId",
                principalTable: "Medici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
