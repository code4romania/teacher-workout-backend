using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherWorkout.Data.Migrations
{
    public partial class AddDefaultLessonState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE \"Lessons\" SET \"State\" = 2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
