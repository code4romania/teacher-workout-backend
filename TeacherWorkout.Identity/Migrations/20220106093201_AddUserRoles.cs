using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherWorkout.Identity.Migrations
{
    public partial class AddUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c1f498cb-4d43-4961-8d3e-d0fd96481f1a", "df0eb0c3-1f6d-4919-846f-9f34cf1e02ce", "Admin", "ADMIN" },
                    { "b654f143-d497-47d0-b417-ff520f9adbfe", "7f97ee55-af03-458d-960a-ae53ae66169d", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b654f143-d497-47d0-b417-ff520f9adbfe");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1f498cb-4d43-4961-8d3e-d0fd96481f1a");
        }
    }
}
