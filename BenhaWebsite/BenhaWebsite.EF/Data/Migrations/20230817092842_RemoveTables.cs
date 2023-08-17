using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenhaWebsite.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewRegitserations");

            migrationBuilder.DropTable(
                name: "StuffArchives");

            migrationBuilder.DropTable(
                name: "TraineesArchives");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewRegitserations",
                columns: table => new
                {
                    NationalID = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeForceHandle = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    College = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePictrue = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    VjudgeHandle = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewRegitserations", x => x.NationalID);
                });

            migrationBuilder.CreateTable(
                name: "StuffArchives",
                columns: table => new
                {
                    NationalID = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeForceHandle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    College = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VjudgeHandle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StuffArchives", x => x.NationalID);
                });

            migrationBuilder.CreateTable(
                name: "TraineesArchives",
                columns: table => new
                {
                    NationalID = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CmapName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeForceHandle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    College = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VjudgeHandle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineesArchives", x => x.NationalID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewRegitserations_CodeForceHandle",
                table: "NewRegitserations",
                column: "CodeForceHandle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewRegitserations_VjudgeHandle",
                table: "NewRegitserations",
                column: "VjudgeHandle",
                unique: true,
                filter: "[VjudgeHandle] IS NOT NULL");
        }
    }
}
