using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TeacherWorkout.Data.Migrations
{
    public partial class SeedDummyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var imageList = new object[,]
            {
                {
                    NewId(),
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg",
                    "Cat Photo"
                },
                {
                    NewId(),
                    "https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg",
                    "Another Cat Photo"
                },
                {
                    NewId(),
                    "https://cdn.shopify.com/s/files/1/1149/5008/articles/why-cat-looking-at-wall-or-nothing.jpg?v=1551321728",
                    "YACP"
                },
                {
                    NewId(),
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcReLDHsAIhgLgFpupyZg0CtevFcI2NY9WkoOQ&usqp=CAU",
                    "More Cat Photos"
                },
                {
                    NewId(), "https://upload.wikimedia.org/wikipedia/commons/e/e6/10_years_old_american_staff.jpg",
                    "Dog Photos"
                },
                {
                    NewId(), "https://upload.wikimedia.org/wikipedia/commons/f/f6/11.10.2015_Samoyed_%28cropped%29.jpg",
                    "More Dog Photos"
                },
                {
                    NewId(),
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/AiredaleDog.jpg/386px-AiredaleDog.jpg",
                    "Cute Dog photo"
                },
                {
                    NewId(),
                    "https://commons.wikimedia.org/wiki/Category:Sitting_dogs#/media/File:Cachorro_ra%C3%A7a_Lhasa_Apso_posando_para_book_canino_perfil.JPG",
                    "Nice dog photo"
                },
                {NewId(), "https://upload.wikimedia.org/wikipedia/commons/9/9a/Paisible.JPG", "Very nice dog photo"},
                {
                    NewId(),
                    "https://commons.wikimedia.org/wiki/Category:Dogs_tilting_head#/media/File:Yumi_19mois2.jpg",
                    "Small dog photo"
                },
                {
                    NewId(),
                    "https://commons.wikimedia.org/wiki/Category:Quality_images_of_dogs#/media/File:Canis_lupus_PO.jpg",
                    "Beautiful dog photo"
                }
            };

            var themeList = new object[,]
            {
                {NewId(), "Lorem Ipsum", imageList[0, 0]},
                {NewId(), "Dolor sit amet", imageList[1, 0]},
                {NewId(), "Consectetur adipiscing elit", imageList[2, 0]},
                {NewId(), "Fusce tempor", imageList[3, 0]},
                {NewId(), "Doloremque laudantium", imageList[4, 0]},
                {NewId(), "Quasi architecto beatae vitae", imageList[5, 0]},
                {NewId(), "Nemo enim ipsam voluptatem", imageList[6, 0]},
                {NewId(), "Sed quia consequuntur magni dolores eos", imageList[7, 0]},
                {NewId(), "Ratione voluptatem sequi nesciunt", imageList[8, 0]},
                {NewId(), "Neque porro quisquam est", imageList[9, 0]},
                {NewId(), "Accusamus et iusto", imageList[10, 0]}
            };
            
            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "Url", "Description" },
                values: imageList);
            
            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "Title", "ThumbnailId" },
                values: themeList);

            for (var themeIndex = 0; themeIndex < 11; themeIndex++)
            {
                var themeId = themeList[themeIndex, 0];
                
                migrationBuilder.InsertData(
                    table: "Lessons",
                    columns: new[] { "Id", "Title", "ThemeId", "Duration", "Description", "ThumbnailId"},
                    values: new object[,]
                    {
                        {NewId(), "Lorem Ipsum", themeId, 45 * 60, "Lorem Ipsum Lorem Ipsum", imageList[0,0]},
                        {NewId(), "Dolor sit amet", themeId, 32 * 60, "Dolor sit amet Dolor sit amet", imageList[1,0]},
                        {NewId(), "Consectetur adipiscing elit", themeId, 55 * 60, "Consectetur adipiscing elit Consectetur adipiscing elit", imageList[2,0]},
                        {NewId(), "Fusce tempor", themeId, 37 * 60, "Fusce tempor Fusce tempor", imageList[3,0]},
                        {NewId(), "Doloremque laudantium", themeId, 39 * 60, "Doloremque laudantium Doloremque laudantium", imageList[4,0]},
                        {NewId(), "Quasi architecto beatae vitae", themeId, 42 * 60, "Quasi architecto beatae vitae Quasi architecto beatae vitae", imageList[5,0]},
                        {NewId(), "Nemo enim ipsam voluptatem", themeId, 49 * 49, "Nemo enim ipsam voluptatem Nemo enim ipsam voluptatem", imageList[6,0]}
                    });
            }
        }

        private string NewId()
        {
            return Guid.NewGuid().ToString();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Lessons");
            migrationBuilder.Sql("DELETE FROM Themes");
            migrationBuilder.Sql("DELETE FROM Image");
        }
    }
}
