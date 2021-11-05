using System.Collections.Generic;
using System.Linq;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.MockData.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private static readonly List<Lesson> Lessons = new()
        {
            new()
            {
                Id = "1",
                Title = "Lorem Ipsum",
                Description = "Lorem Ipsum",
                State = LessonState.Draft,
                Thumbnail = new Image
                {
                    Description = "Cat Photo",
                    Url =
                        "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"

                },
                Theme = new Theme
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
                Duration = new Duration
                {
                    Value = 45,
                    Unit = DurationUnit.Minutes
                }
            },
            new()
            {
                Id = "2",
                Title = "Dolor sit amet",
                Description = "Dolor sit amet",
                State = LessonState.Draft,
                Thumbnail = new Image
                {
                    Description = "Another Cat Photo",
                    Url =
                        "https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg"
                },
                Theme = new Theme
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
                Duration = new Duration
                {
                    Value = 32,
                    Unit = DurationUnit.Minutes
                }
            },
            new()
            {
                Id = "3",
                Title = "Consectetur adipiscing elit",
                Description = "Consectetur adipiscing elit",
                State = LessonState.Published,
                Thumbnail = new Image
                {
                    Description = "YACP",
                    Url =
                        "http://cdn.shopify.com/s/files/1/1149/5008/articles/why-cat-looking-at-wall-or-nothing.jpg?v=1551321728"
                },
                Theme = new Theme
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
                Duration = new Duration
                {
                    Value = 55,
                    Unit = DurationUnit.Minutes
                }
            },
            new()
            {
                Id = "4",
                Title = "Fusce tempor",
                Description = "Fusce tempor",
                State = LessonState.Published,
                Thumbnail = new Image
                {
                    Description = "More Cat Photos",
                    Url =
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcReLDHsAIhgLgFpupyZg0CtevFcI2NY9WkoOQ&usqp=CAU"
                },
                Theme = new Theme
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
                Duration = new Duration
                {
                    Value = 37,
                    Unit = DurationUnit.Minutes
                }
            },
            new()
            {
                Id = "5",
                Title = "Doloremque laudantium",
                Description = "Doloremque laudantium",
                State = LessonState.Published,
                Thumbnail = new Image
                {
                    Description = "Dog Photos",
                    Url = "https://upload.wikimedia.org/wikipedia/commons/e/e6/10_years_old_american_staff.jpg"
                },
                Theme = new Theme
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
                Duration = new Duration
                {
                    Value = 39,
                    Unit = DurationUnit.Minutes
                }
            },
            new()
            {
                Id = "6",
                Title = "Quasi architecto beatae vitae",
                Description = "Quasi architecto beatae vitae",
                State = LessonState.Draft,
                Thumbnail = new Image
                {
                    Description = "More Dog Photos",
                    Url = "https://upload.wikimedia.org/wikipedia/commons/f/f6/11.10.2015_Samoyed_%28cropped%29.jpg"
                },
                Theme = new Theme
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
                Duration = new Duration
                {
                    Value = 42,
                    Unit = DurationUnit.Minutes
                }
            },
            new()
            {
                Id = "7",
                Title = "Nemo enim ipsam voluptatem",
                Description = "Nemo enim ipsam voluptatem",
                State = LessonState.Draft,
                Thumbnail = new Image
                {
                    Description = "Cute Dog photo",
                    Url =
                        "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/AiredaleDog.jpg/386px-AiredaleDog.jpg"
                },
                Theme = new Theme
                {
                    Id = "9",
                    Title = "Ratione voluptatem sequi nesciunt",
                    Thumbnail = new Image
                    {
                        Description = "Very nice dog photo",
                        Url = "https://upload.wikimedia.org/wikipedia/commons/9/9a/Paisible.JPG"
                    }
                },
                Duration = new Duration
                {
                    Value = 45,
                    Unit = DurationUnit.Minutes
                }
            },
            new()
            {
                Id = "8",
                Title = "Sed quia consequuntur magni dolores eos",
                Description = "Sed quia consequuntur magni dolores eos",
                State = LessonState.Published,
                Thumbnail = new Image
                {
                    Description = "Nice dog photo",
                    Url =
                        "https://commons.wikimedia.org/wiki/Category:Sitting_dogs#/media/File:Cachorro_ra%C3%A7a_Lhasa_Apso_posando_para_book_canino_perfil.JPG"
                },
                Theme = new Theme
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
                Duration = new Duration
                {
                    Value = 44,
                    Unit = DurationUnit.Minutes
                }
            },
            new()
            {
                Id = "9",
                Title = "Ratione voluptatem sequi nesciunt",
                Description = "Ratione voluptatem sequi nesciunt",
                State = LessonState.Published,
                Thumbnail = new Image
                {
                    Description = "Very nice dog photo",
                    Url = "https://upload.wikimedia.org/wikipedia/commons/9/9a/Paisible.JPG"
                },
                Theme = new Theme
                {
                    Id = "11",
                    Title = "Accusamus et iusto",
                    Thumbnail = new Image
                    {
                        Description = "Beautiful dog photo",
                        Url =
                            "https://commons.wikimedia.org/wiki/Category:Quality_images_of_dogs#/media/File:Canis_lupus_PO.jpg"
                    }
                },
                Duration = new Duration
                {
                    Value = 43,
                    Unit = DurationUnit.Minutes
                }
            },
            new()
            {
                Id = "10",
                Title = "Neque porro quisquam est",
                Description = "Neque porro quisquam est",
                State = LessonState.Draft,
                Thumbnail = new Image
                {
                    Description = "Small dog photo",
                    Url = "https://commons.wikimedia.org/wiki/Category:Dogs_tilting_head#/media/File:Yumi_19mois2.jpg"
                },
                Theme = new Theme
                {
                    Id = "5",
                    Title = "Doloremque laudantium",
                    Thumbnail = new Image
                    {
                        Description = "Dog Photos",
                        Url = "https://upload.wikimedia.org/wikipedia/commons/e/e6/10_years_old_american_staff.jpg"
                    }
                },
                Duration = new Duration
                {
                    Value = 46,
                    Unit = DurationUnit.Minutes
                }
            },
            new()
            {
                Id = "11",
                Title = "Accusamus et iusto",
                Description = "Accusamus et iusto",
                State = LessonState.Published,
                Thumbnail = new Image
                {
                    Description = "Beautiful dog photo",
                    Url =
                        "https://commons.wikimedia.org/wiki/Category:Quality_images_of_dogs#/media/File:Canis_lupus_PO.jpg"
                },
                Theme = new Theme
                {
                    Id = "6",
                    Title = "Quasi architecto beatae vitae",
                    Thumbnail = new Image
                    {
                        Description = "More Dog Photos",
                        Url = "https://upload.wikimedia.org/wikipedia/commons/f/f6/11.10.2015_Samoyed_%28cropped%29.jpg"
                    }
                },
                Duration = new Duration
                {
                    Value = 49,
                    Unit = DurationUnit.Minutes
                }
            }
        };

        public PaginatedResult<Lesson> PaginatedList(LessonFilter filter)
        {
            var lessons = Lessons;

            if (!string.IsNullOrEmpty(filter.ThemeId))
            {
                lessons = lessons.Where(l => l.Theme.Id == filter.ThemeId).ToList();
            }

            if (filter.State.HasValue)
            {
                lessons = lessons.Where(l => l.State == filter.State).ToList();
            }

            return new PaginatedResult<Lesson>
            {
                Items = lessons,
                TotalCount = lessons.Count
            };
        }
    }
}