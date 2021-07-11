using TeacherWorkout.Api.Models;
using TeacherWorkout.Api.Models.Inputs;
using TeacherWorkout.Api.Models.Payloads;

namespace TeacherWorkout.Api.GraphQL.Resolvers

{
    public static class LessonSaveResolver
    {
        public static LessonSavePayload Resolve(LessonSaveInput lessonSave)
        {
            return new() {Lesson = MockData(lessonSave)};
        }

        private static Lesson MockData(LessonSaveInput lessonSave)
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