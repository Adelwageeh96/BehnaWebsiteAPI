﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenhaWebsite.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSheetsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampId",
                table: "Sheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SheetOrder",
                table: "Sheets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sheets_CampId",
                table: "Sheets",
                column: "CampId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sheets_Camps_CampId",
                table: "Sheets",
                column: "CampId",
                principalTable: "Camps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sheets_Camps_CampId",
                table: "Sheets");

            migrationBuilder.DropIndex(
                name: "IX_Sheets_CampId",
                table: "Sheets");

            migrationBuilder.DropColumn(
                name: "CampId",
                table: "Sheets");

            migrationBuilder.DropColumn(
                name: "SheetOrder",
                table: "Sheets");
        }
    }
}
