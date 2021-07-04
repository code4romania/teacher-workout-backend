using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Resolvers

{
    public static class LessonSaveResolver
    {
        public static Lesson MockData(LessonSave lessonSave)
        {
            return new()
            {
                Id = lessonSave.LessonId,
                Title = "Lorem Ipsum",
                Thumbnail = new Image
                {
                    Description = "For Challenged People",
                    Url = "https://example.com"
                },
                Theme = new Theme
                {
                    Id = "1",
                    Title = "Lorem Ipsum",
                    Thumbnail = new Image
                    {
                        Description = "For Challenged People",
                        Url = "https://example.com"
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