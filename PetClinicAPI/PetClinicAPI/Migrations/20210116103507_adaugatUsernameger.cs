using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetClinicAPI.Migrations
{
    public partial class adaugatUsernameger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Utilizatori",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Utilizatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Utilizatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Utilizatori",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Utilizatori",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Utilizatori",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Utilizatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Utilizatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Utilizatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Utilizatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Utilizatori",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Utilizatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Utilizatori",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Utilizatori",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Utilizatori");
        }
    }
}
