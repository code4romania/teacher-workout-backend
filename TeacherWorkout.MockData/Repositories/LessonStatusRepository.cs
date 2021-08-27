using System.Collections.Generic;
using System.Linq;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.MockData.Repositories
{
    public class LessonStatusRepository : ILessonStatusRepository
    {
        public IEnumerable<LessonStatus> List(LessonStatusFilter filter)
        {
            return filter.LessonIds
                .Select(lessonId => new LessonStatus
                {
                    Lesson = new Lesson
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
                    },
                    PercentCompleted = 10,
                    CurrentLessonStep = new SlideStep
                    {
                        Id = "1",
                        Title = "My title 1",
                        Description =
                            "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum;",
                        Image = new Image
                        {
                            Description = "Cat Photo",
                            Url =
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                        },
                        PreviousStep = null
                    }
                });
        }
    }
}
