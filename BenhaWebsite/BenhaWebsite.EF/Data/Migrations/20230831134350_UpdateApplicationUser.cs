using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenhaWebsite.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_VjudgeHandle",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "College",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "VjudgeHandle",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "College",
                table: "Accounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte>(
                name: "Grade",
                table: "Accounts",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "VjudgeHandle",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_VjudgeHandle",
                table: "Accounts",
                column: "VjudgeHandle",
                unique: true,
                filter: "VjudgeHandle IS NOT NULL");
        }
    }
}
