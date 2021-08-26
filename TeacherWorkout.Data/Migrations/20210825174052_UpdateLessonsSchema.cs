using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TeacherWorkout.Data.Migrations
{
    public partial class UpdateLessonsSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });
            
            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(nullable: false),
                    ThumbnailId = table.Column<int?>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.RenameColumn("Name", "Lessons", "Title");
            migrationBuilder.AddColumn<string>("Description", "Lessons", nullable: true);
            migrationBuilder.AddColumn<int>("Duration", "Lessons", nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "ThemeId",
                table: "Lessons",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ThemeId",
                table: "Lessons",
                column: "ThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Theme",
                table: "Lessons",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            
            migrationBuilder.AddColumn<int?>("ThumbnailId", "Lessons", nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lesson_Image",
                table: "Lessons",
                column: "ThumbnailId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex("IX_Lessons_ThemeId", "Lessons");
            migrationBuilder.DropForeignKey("FK_Lesson_Theme", "Lessons");
            migrationBuilder.DropColumn("ThumbnailId", "Lessons");

            migrationBuilder.DropForeignKey("FK_Lesson_Image", "Lessons");
            migrationBuilder.DropColumn("ThumbnailId", "Lessons");

            migrationBuilder.DropColumn("Description", "Lessons");
            migrationBuilder.DropColumn("ThemeId", "Lessons");
            migrationBuilder.RenameColumn("Title", "Lessons", "Name");
            
            migrationBuilder.DropTable(name: "Themes");
            migrationBuilder.DropTable(name: "Images");
        }
    }
}
