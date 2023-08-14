using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenhaWebsite.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHeadOfCampTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HeadOfCampId",
                table: "Camps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Accounts",
                type: "nchar(11)",
                fixedLength: true,
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "Accounts",
                type: "nchar(14)",
                fixedLength: true,
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.CreateTable(
                name: "HeadOfCamp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadOfCamp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadOfCamp_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Camps_HeadOfCampId",
                table: "Camps",
                column: "HeadOfCampId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadOfCamp_UserId",
                table: "HeadOfCamp",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Camps_HeadOfCamp_HeadOfCampId",
                table: "Camps",
                column: "HeadOfCampId",
                principalTable: "HeadOfCamp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Camps_HeadOfCamp_HeadOfCampId",
                table: "Camps");

            migrationBuilder.DropTable(
                name: "HeadOfCamp");

            migrationBuilder.DropIndex(
                name: "IX_Camps_HeadOfCampId",
                table: "Camps");

            migrationBuilder.DropColumn(
                name: "HeadOfCampId",
                table: "Camps");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Accounts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(11)",
                oldFixedLength: true,
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalId",
                table: "Accounts",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(14)",
                oldFixedLength: true,
                oldMaxLength: 14);
        }
    }
}
