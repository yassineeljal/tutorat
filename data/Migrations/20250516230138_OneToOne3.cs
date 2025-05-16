using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class OneToOne3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TutorId",
                table: "Students",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_TutorId",
                table: "Students",
                column: "TutorId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Tutors_TutorId",
                table: "Students",
                column: "TutorId",
                principalTable: "Tutors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Tutors_TutorId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_TutorId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TutorId",
                table: "Students");
        }
    }
}
