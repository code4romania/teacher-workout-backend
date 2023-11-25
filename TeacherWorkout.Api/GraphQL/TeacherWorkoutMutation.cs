using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using TeacherWorkout.Api.GraphQL.Resolvers;
using TeacherWorkout.Api.GraphQL.Types.Inputs;
using TeacherWorkout.Api.GraphQL.Types.Payloads;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models.Inputs;
using TeacherWorkout.Domain.Models.Payloads;
using TeacherWorkout.Domain.Themes;

namespace TeacherWorkout.Api.GraphQL
{
    public class TeacherWorkoutMutation : ObjectGraphType<object>
    {
        public TeacherWorkoutMutation(CompleteStep completeStep,
            CreateTheme createTheme,
            UpdateTheme updateTheme)
        {
            Name = "Mutation";

            Field<NonNullGraphType<LessonSavePayloadType>>("lessonSave")
                .Argument<NonNullGraphType<LessonSaveInputType>>(Name = "input")
                .Resolve(context =>
                {
                    var lessonSave = context.GetArgument<LessonSaveInput>("input");
                    return LessonSaveResolver.Resolve(lessonSave);
                });

            Field<StepCompletePayloadType>("stepComplete")
                .Argument<NonNullGraphType<StepCompleteInputType>>(Name = "input")
                .Resolve(context =>
                {
                    var input = context.GetArgument<StepCompleteInput>("input");
                    return completeStep.Execute(input);
                });

            Field<ThemeCreatePayloadType>("themeCreate")
                .Argument<NonNullGraphType<ThemeCreateInputType>>(Name = "input")
                .Resolve(context =>
                {
                    var input = context.GetArgument<ThemeCreateInput>("input");
                    return createTheme.Execute(input);
                });

            Field<ThemeUpdatePayloadType>("themeUpdate")
                .Argument<NonNullGraphType<ThemeUpdateInputType>>(Name = "input")
                .Resolve(context =>
                {
                    var input = context.GetArgument<ThemeUpdateInput>("input");
                    return updateTheme.Execute(input);
                });
        }
    }
}