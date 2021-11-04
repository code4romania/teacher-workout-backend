using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherWorkout.Data.Migrations
{
    public partial class AddImagesRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Image_ThumbnailId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Themes_Image_ThumbnailId",
                table: "Themes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image",
                table: "Image");

            migrationBuilder.RenameTable(
                name: "Image",
                newName: "Images");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Images_ThumbnailId",
                table: "Lessons",
                column: "ThumbnailId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_Images_ThumbnailId",
                table: "Themes",
                column: "ThumbnailId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Images_ThumbnailId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Themes_Images_ThumbnailId",
                table: "Themes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Image");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image",
                table: "Image",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Image_ThumbnailId",
                table: "Lessons",
                column: "ThumbnailId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_Image_ThumbnailId",
                table: "Themes",
                column: "ThumbnailId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
