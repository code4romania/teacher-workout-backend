using GraphQL;
using GraphQL.Types;
using TeacherWorkout.Api.GraphQL.Types;
using TeacherWorkout.Api.Models;
using LessonSaveInput = TeacherWorkout.Api.GraphQL.Inputs.LessonSaveInput;

namespace TeacherWorkout.Api.GraphQL
{
    public class TeacherWorkoutMutation : ObjectGraphType<object>
    {
        public TeacherWorkoutMutation(LessonSaveInput input)
        {
            Name = "Mutation";

            Field<LessonSavePayloadType>(
                "lessonSave",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<LessonSaveInput>> {Name = "input"}
                ),
                resolve: context => new LessonSavePayload
                {
                    Lesson = new Lesson
                    {
                        Id = "42",
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
                    }
                });
        }
    }
}