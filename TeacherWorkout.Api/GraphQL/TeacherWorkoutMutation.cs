using GraphQL;
using GraphQL.Types;
using TeacherWorkout.Api.GraphQL.Resolvers;
using TeacherWorkout.Api.GraphQL.Types.Inputs;
using TeacherWorkout.Api.GraphQL.Types.Payloads;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models.Inputs;
using TeacherWorkout.Domain.Themes;

namespace TeacherWorkout.Api.GraphQL
{
    public class TeacherWorkoutMutation : ObjectGraphType<object>
    {
        public TeacherWorkoutMutation(CompleteStep completeStep,
            CreateTheme createTheme)
        {
            Name = "Mutation";

            Field<NonNullGraphType<LessonSavePayloadType>>(
                "lessonSave",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<LessonSaveInputType>> { Name = "input" }
                ),
                resolve: context =>
                {
                    var lessonSave = context.GetArgument<LessonSaveInput>("input");
                    return LessonSaveResolver.Resolve(lessonSave);
                });

            Field<StepCompletePayloadType>(
                "stepComplete",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StepCompleteInputType>> { Name = "input" }
                ),
                resolve: context =>
                {
                    var input = context.GetArgument<StepCompleteInput>("input");
                    return completeStep.Execute(input);
                });

            Field<ThemeCreatePayloadType>(
                "themeCreate",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ThemeCreateInputType>> { Name = "input" }
                ),
                resolve: context =>
                {
                    var input = context.GetArgument<ThemeCreateInput>("input");
                    return createTheme.Execute(input);
                });
        }
    }
}