using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wilson.JogoDaVelha.Repository.Migrations
{
    public partial class AddBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EditedAt",
                table: "players");

            migrationBuilder.DropColumn(
                name: "EditedAt",
                table: "games");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Plays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "games",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Plays");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "players");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "games");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedAt",
                table: "players",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedAt",
                table: "games",
                type: "datetime2",
                nullable: true);
        }
    }
}
