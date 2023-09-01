using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BenhaWebsite.EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRealations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Camps_HeadOfCamp_HeadOfCampId",
                table: "Camps");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheets_Camps_CampId",
                table: "Sheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Mentors_MentorId",
                table: "Trainees");

            migrationBuilder.AlterColumn<int>(
                name: "MentorId",
                table: "Trainees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CampId",
                table: "Sheets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "HeadOfCampId",
                table: "Camps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Camps_HeadOfCamp_HeadOfCampId",
                table: "Camps",
                column: "HeadOfCampId",
                principalTable: "HeadOfCamp",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheets_Camps_CampId",
                table: "Sheets",
                column: "CampId",
                principalTable: "Camps",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Mentors_MentorId",
                table: "Trainees",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Camps_HeadOfCamp_HeadOfCampId",
                table: "Camps");

            migrationBuilder.DropForeignKey(
                name: "FK_Sheets_Camps_CampId",
                table: "Sheets");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Mentors_MentorId",
                table: "Trainees");

            migrationBuilder.AlterColumn<int>(
                name: "MentorId",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CampId",
                table: "Sheets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HeadOfCampId",
                table: "Camps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Camps_HeadOfCamp_HeadOfCampId",
                table: "Camps",
                column: "HeadOfCampId",
                principalTable: "HeadOfCamp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sheets_Camps_CampId",
                table: "Sheets",
                column: "CampId",
                principalTable: "Camps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Mentors_MentorId",
                table: "Trainees",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
