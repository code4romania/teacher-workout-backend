namespace TeacherWorkout.Api.Models
{
    public class Lesson
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public Image Thumbnail { get; set; }
        
        public Theme Theme { get; set; }
        
        public Duration Duration { get; set; }

        public static Lesson BuildMock(string lessonId = "1")
        {
            return new()
            {
                Id = lessonId,
                Title = "Lorem Ipsum",
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
            };
        }
    }
}