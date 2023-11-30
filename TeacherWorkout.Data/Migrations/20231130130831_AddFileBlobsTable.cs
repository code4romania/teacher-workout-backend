using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeacherWorkout.Data.Migrations
{
    public partial class AddFileBlobsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileBlobId",
                table: "Images",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FileBlobs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<byte[]>(type: "bytea", nullable: false),
                    Mimetype = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileBlobs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_FileBlobId",
                table: "Images",
                column: "FileBlobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_FileBlobs_FileBlobId",
                table: "Images",
                column: "FileBlobId",
                principalTable: "FileBlobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_FileBlobs_FileBlobId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_FileBlobId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "FileBlobs");

            migrationBuilder.DropColumn(
                name: "FileBlobId",
                table: "Images");
        }
    }
}
