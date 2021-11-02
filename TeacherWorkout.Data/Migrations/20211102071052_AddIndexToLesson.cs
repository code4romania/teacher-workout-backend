using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherWorkout.Data.Migrations
{
    public partial class AddIndexToLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lessons_ThemeId",
                table: "Lessons");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ThemeId_State",
                table: "Lessons",
                columns: new[] { "ThemeId", "State" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Lessons_ThemeId_State",
                table: "Lessons");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ThemeId",
                table: "Lessons",
                column: "ThemeId");
        }
    }
}
