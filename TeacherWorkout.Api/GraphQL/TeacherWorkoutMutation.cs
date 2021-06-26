using GraphQL;
using GraphQL.Types;
using TeacherWorkout.Api.GraphQL.Inputs;
using TeacherWorkout.Api.GraphQL.Resolvers;
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
                    Lesson = LessonSaveResolver.MockData()
                });

            Field<StepCompletePayloadType>(
                "stepComplete",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StepCompleteInput>> {Name = "input"}
                ),
                resolve: context => new StepCompletePayload()
                {
                    Step = new SlideStep
                    {
                        Id = "1",
                        Title = "My title 1",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum;",
                        Image = new Image
                        {
                            Description = "Cat Photo",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                        },
                        PreviousStep = null
                    }
                });
        }
    }
}