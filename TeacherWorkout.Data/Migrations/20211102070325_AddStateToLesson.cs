using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherWorkout.Data.Migrations
{
    public partial class AddStateToLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Lessons");
        }
    }
}
