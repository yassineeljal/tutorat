using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class laison2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Students_StudentId",
                table: "Availabilities");

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_Students_StudentId",
                table: "Availabilities",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availabilities_Students_StudentId",
                table: "Availabilities");

            migrationBuilder.AddForeignKey(
                name: "FK_Availabilities_Students_StudentId",
                table: "Availabilities",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
