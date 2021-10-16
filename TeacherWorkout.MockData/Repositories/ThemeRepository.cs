using System.Collections.Generic;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Themes;

namespace TeacherWorkout.MockData.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        public PaginatedResult<Theme> PaginatedList(PaginationFilter pagination)
        {
            return new()
            {
                TotalCount = 11,
                Items = new List<Theme>
                {
                    new()
                    {
                        Id = "1",
                        Title = "Lorem Ipsum",
                        Thumbnail = new Image
                        {
                            Description = "Cat Photo",
                            Url =
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                        }
                    },
                    new()
                    {
                        Id = "2",
                        Title = "Dolor sit amet",
                        Thumbnail = new Image
                        {
                            Description = "Another Cat Photo",
                            Url =
                                "https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg"
                        }
                    },
                    new()
                    {
                        Id = "3",
                        Title = "Consectetur adipiscing elit",
                        Thumbnail = new Image
                        {
                            Description = "YACP",
                            Url =
                                "http://cdn.shopify.com/s/files/1/1149/5008/articles/why-cat-looking-at-wall-or-nothing.jpg?v=1551321728"
                        }
                    },
                    new()
                    {
                        Id = "4",
                        Title = "Fusce tempor",
                        Thumbnail = new Image
                        {
                            Description = "More Cat Photos",
                            Url =
                                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcReLDHsAIhgLgFpupyZg0CtevFcI2NY9WkoOQ&usqp=CAU"
                        }
                    },
                    new()
                    {
                        Id = "5",
                        Title = "Doloremque laudantium",
                        Thumbnail = new Image
                        {
                            Description = "Dog Photos",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/e/e6/10_years_old_american_staff.jpg"
                        }
                    },
                    new()
                    {
                        Id = "6",
                        Title = "Quasi architecto beatae vitae",
                        Thumbnail = new Image
                        {
                            Description = "More Dog Photos",
                            Url =
                                "https://upload.wikimedia.org/wikipedia/commons/f/f6/11.10.2015_Samoyed_%28cropped%29.jpg"
                        }
                    },
                    new()
                    {
                        Id = "7",
                        Title = "Nemo enim ipsam voluptatem",
                        Thumbnail = new Image
                        {
                            Description = "Cute Dog photo",
                            Url =
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/AiredaleDog.jpg/386px-AiredaleDog.jpg"
                        }
                    },
                    new()
                    {
                        Id = "8",
                        Title = "Sed quia consequuntur magni dolores eos",
                        Thumbnail = new Image
                        {
                            Description = "Nice dog photo",
                            Url =
                                "https://commons.wikimedia.org/wiki/Category:Sitting_dogs#/media/File:Cachorro_ra%C3%A7a_Lhasa_Apso_posando_para_book_canino_perfil.JPG"
                        }
                    },
                    new()
                    {
                        Id = "9",
                        Title = "Ratione voluptatem sequi nesciunt",
                        Thumbnail = new Image
                        {
                            Description = "Very nice dog photo",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/9/9a/Paisible.JPG"
                        }
                    },
                    new()
                    {
                        Id = "10",
                        Title = "Neque porro quisquam est",
                        Thumbnail = new Image
                        {
                            Description = "Small dog photo",
                            Url =
                                "https://commons.wikimedia.org/wiki/Category:Dogs_tilting_head#/media/File:Yumi_19mois2.jpg"
                        }
                    },
                    new()
                    {
                        Id = "11",
                        Title = "Accusamus et iusto",
                        Thumbnail = new Image
                        {
                            Description = "Beautiful dog photo",
                            Url =
                                "https://commons.wikimedia.org/wiki/Category:Quality_images_of_dogs#/media/File:Canis_lupus_PO.jpg"
                        }
                    }
                }
            };
        }

        public void Insert(Theme theme)
        {
        }
    }
}