using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenhaWebsite.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_VjudgeHandle",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_VjudgeHandle",
                table: "Accounts",
                column: "VjudgeHandle",
                unique: true,
                filter: "VjudgeHandle IS NOT NULL");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Gender",
                table: "Accounts",
                sql: "Gender in ('Male','Female')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Accounts_VjudgeHandle",
                table: "Accounts");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Gender",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Accounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_VjudgeHandle",
                table: "Accounts",
                column: "VjudgeHandle",
                unique: true,
                filter: "[VjudgeHandle] IS NOT NULL");
        }
    }
}
