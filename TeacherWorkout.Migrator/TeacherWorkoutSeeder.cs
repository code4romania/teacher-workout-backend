using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeacherWorkout.Data;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Migrator
{
    public class TeacherWorkoutSeeder
    {
        private readonly TeacherWorkoutContext _context;

        private readonly List<Image> _images = new()
        {
            new()
            {
                Id = "1",
                Description = "Cat Photo",
                Url =
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
            },
            new()
            {
                Id = "2",
                Description = "Another Cat Photo",
                Url =
                    "https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg"
            },
            new()
            {
                Id = "3",
                Description = "YACP",
                Url =
                    "http://cdn.shopify.com/s/files/1/1149/5008/articles/why-cat-looking-at-wall-or-nothing.jpg?v=1551321728"
            },
            new()
            {
                Id = "4",
                Description = "More Cat Photos",
                Url =
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcReLDHsAIhgLgFpupyZg0CtevFcI2NY9WkoOQ&usqp=CAU"
            },
            new()
            {
                Id = "5",
                Description = "Dog Photos",
                Url = "https://upload.wikimedia.org/wikipedia/commons/e/e6/10_years_old_american_staff.jpg"
            },
            new()
            {
                Id = "6",
                Description = "More Dog Photos",
                Url =
                    "https://upload.wikimedia.org/wikipedia/commons/f/f6/11.10.2015_Samoyed_%28cropped%29.jpg"
            },
            new()
            {
                Id = "7",
                Description = "Cute Dog photo",
                Url =
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/AiredaleDog.jpg/386px-AiredaleDog.jpg"
            },
            new()
            {
                Id = "8",
                Description = "Nice dog photo",
                Url =
                    "https://commons.wikimedia.org/wiki/Category:Sitting_dogs#/media/File:Cachorro_ra%C3%A7a_Lhasa_Apso_posando_para_book_canino_perfil.JPG"
            },
            new()
            {
                Id = "9",
                Description = "Very nice dog photo",
                Url = "https://upload.wikimedia.org/wikipedia/commons/9/9a/Paisible.JPG"
            },
            new()
            {
                Id = "10",
                Description = "Small dog photo",
                Url =
                    "https://commons.wikimedia.org/wiki/Category:Dogs_tilting_head#/media/File:Yumi_19mois2.jpg"
            },
            new()
            {
                Id = "11",
                Description = "Beautiful dog photo",
                Url =
                    "https://commons.wikimedia.org/wiki/Category:Quality_images_of_dogs#/media/File:Canis_lupus_PO.jpg"
            }
        };

        private readonly List<Theme> _themes = new()
        {
            new()
            {
                Id = "1",
                Title = "Lorem Ipsum",
                ThumbnailId = "1"
            },
            new()
            {
                Id = "2",
                Title = "Dolor sit amet",
                ThumbnailId = "2"
            },
            new()
            {
                Id = "3",
                Title = "Consectetur adipiscing elit",
                ThumbnailId = "3"
            },
            new()
            {
                Id = "4",
                Title = "Fusce tempor",
                ThumbnailId = "4"
            },
            new()
            {
                Id = "5",
                Title = "Doloremque laudantium",
                ThumbnailId = "5"
            },
            new()
            {
                Id = "6",
                Title = "Quasi architecto beatae vitae",
                ThumbnailId = "6"
            },
            new()
            {
                Id = "7",
                Title = "Nemo enim ipsam voluptatem",
                ThumbnailId = "7"
            },
            new()
            {
                Id = "8",
                Title = "Sed quia consequuntur magni dolores eos",
                ThumbnailId = "8"
            },
            new()
            {
                Id = "9",
                Title = "Ratione voluptatem sequi nesciunt",
                ThumbnailId = "9"
            },
            new()
            {
                Id = "10",
                Title = "Neque porro quisquam est",
                ThumbnailId = "10"
            },
            new()
            {
                Id = "11",
                Title = "Accusamus et iusto",
                ThumbnailId = "11"
            }
        };

        private readonly List<Lesson> _lessons = new()
        {
            new()
            {
                Id = "1",
                Title = "Lorem Ipsum",
                ThumbnailId = "1",
                ThemeId = "1",
                Duration = new Duration
                {
                    Value = 45,
                    Unit = DurationUnit.Minutes
                },
                State = LessonState.Draft
            },
            new()
            {
                Id = "2",
                Title = "Dolor sit amet",
                ThumbnailId = "2",
                ThemeId = "1",
                Duration = new Duration
                {
                    Value = 32,
                    Unit = DurationUnit.Minutes
                },
                State = LessonState.Published
            },
            new()
            {
                Id = "3",
                Title = "Consectetur adipiscing elit",
                ThumbnailId = "3",
                ThemeId = "1",
                Duration = new Duration
                {
                    Value = 55,
                    Unit = DurationUnit.Minutes
                },
                State = LessonState.Draft
            },
            new()
            {
                Id = "4",
                Title = "Fusce tempor",
                ThumbnailId = "4",
                ThemeId = "1",
                Duration = new Duration
                {
                    Value = 37,
                    Unit = DurationUnit.Minutes
                },
                State = LessonState.Published
            },
            new()
            {
                Id = "5",
                Title = "Doloremque laudantium",
                ThumbnailId = "5",
                ThemeId = "7", 
                Duration = new Duration
                {
                    Value = 39,
                    Unit = DurationUnit.Minutes
                },
                State = LessonState.Draft
            },
            new()
            {
                Id = "6",
                Title = "Quasi architecto beatae vitae",
                ThumbnailId = "6",
                ThemeId = "8",
                Duration = new Duration
                {
                    Value = 42,
                    Unit = DurationUnit.Minutes
                },
                State = LessonState.Published
            },
            new()
            {
                Id = "7",
                Title = "Nemo enim ipsam voluptatem",
                ThumbnailId = "7",
                ThemeId = "9",
                Duration = new Duration
                {
                    Value = 45,
                    Unit = DurationUnit.Minutes
                },
                State = LessonState.Draft
            },
            new()
            {
                Id = "8",
                Title = "Sed quia consequuntur magni dolores eos",
                ThumbnailId = "8",
                ThemeId = "10",
                Duration = new Duration
                {
                    Value = 44,
                    Unit = DurationUnit.Minutes
                },
                State = LessonState.Published
            },
            new()
            {
                Id = "9",
                Title = "Ratione voluptatem sequi nesciunt",
                ThumbnailId = "9",
                ThemeId = "11",
                Duration = new Duration
                {
                    Value = 43,
                    Unit = DurationUnit.Minutes
                },
                State = LessonState.Draft
            },
            new()
            {
                Id = "10",
                Title = "Neque porro quisquam est",
                ThumbnailId = "10",
                ThemeId = "5",
                Duration = new Duration
                {
                    Value = 46,
                    Unit = DurationUnit.Minutes
                },
                State = LessonState.Published
            },
            new()
            {
                Id = "11",
                Title = "Accusamus et iusto",
                ThumbnailId = "11",
                ThemeId = "6",
                Duration = new Duration
                {
                    Value = 49,
                    Unit = DurationUnit.Minutes
                },
                State = LessonState.Published
            }
        };

        public TeacherWorkoutSeeder(TeacherWorkoutContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            var lessonIds = _lessons.Select(l => l.Id).ToList();
            var alreadySeeded = await _context.Lessons.AnyAsync(l => lessonIds.Contains(l.Id));
            if (alreadySeeded)
            {
                Console.WriteLine("Database has already been seeded. If you want to re-seed, truncate the old data first and re-run migrator.");
                return;
            }

            await _context.AddRangeAsync(_images);
            await _context.AddRangeAsync(_themes);
            await _context.AddRangeAsync(_lessons);

            await _context.SaveChangesAsync();
        }
    }
}
