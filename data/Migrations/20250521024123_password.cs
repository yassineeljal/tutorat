using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class password : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Tutors_TutorId",
                table: "Availabilities");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Tutors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Da",
                table: "Teachers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Teachers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_Tutors_TutorId",
                table: "Availabilities",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Tutors_TutorId",
                table: "Availabilities");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Tutors");

            migrationBuilder.DropColumn(
                name: "Da",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_Tutors_TutorId",
                table: "Availabilities",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "Id");
        }
    }
}
