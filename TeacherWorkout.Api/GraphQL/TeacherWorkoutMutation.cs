using GraphQL;
using GraphQL.Types;
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
                resolve: context =>
                {
                    var lessonSave = context.GetArgument<LessonSave>("input");
                    return new LessonSavePayload
                    {
                        Lesson = LessonSaveResolver.MockData(lessonSave)
                    };
                });
        }
    }
}