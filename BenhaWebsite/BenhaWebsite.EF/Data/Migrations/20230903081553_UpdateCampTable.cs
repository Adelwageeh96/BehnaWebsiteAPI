using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenhaWebsite.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCampTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Term",
                table: "Camps");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Camps");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTime",
                table: "Camps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTime",
                table: "Camps");

            migrationBuilder.AddColumn<int>(
                name: "Term",
                table: "Camps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Camps",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
