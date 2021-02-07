using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinicAPI.Migrations
{
    public partial class addBackUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StapanId",
                table: "Animale",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Utilizatori",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdUtilizator = table.Column<long>(type: "bigint", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Preume = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CNP = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    eAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizatori", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animale_StapanId",
                table: "Animale",
                column: "StapanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animale_Utilizatori_StapanId",
                table: "Animale",
                column: "StapanId",
                principalTable: "Utilizatori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animale_Utilizatori_StapanId",
                table: "Animale");

            migrationBuilder.DropTable(
                name: "Utilizatori");

            migrationBuilder.DropIndex(
                name: "IX_Animale_StapanId",
                table: "Animale");

            migrationBuilder.DropColumn(
                name: "StapanId",
                table: "Animale");
        }
    }
}
