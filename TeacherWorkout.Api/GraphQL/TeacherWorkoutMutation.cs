using System.ComponentModel.DataAnnotations;
using System.IO;
using GraphQL;
using GraphQL.Types;
using GraphQL.Upload.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TeacherWorkout.Api.GraphQL.Resolvers;
using TeacherWorkout.Api.GraphQL.Types.Inputs;
using TeacherWorkout.Api.GraphQL.Types.Payloads;
using TeacherWorkout.Domain.FileBlobs;
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
            UpdateTheme updateTheme,
            SingleUpload singleUpload,
            IConfiguration configuration)
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


            Field<SingleUploadPayloadType>("singleUpload")
                .Argument<NonNullGraphType<UploadGraphType>>(Name = "file")
                .Resolve(context =>
                {
                    var file = context.GetArgument<IFormFile>("file");
                    
                    var maxFileSizeMb = configuration.GetValue("TeacherWorkout:MaxFileSizeMb", 5);
                    if (file.Length > maxFileSizeMb * 1024 * 1024)
                    {
                        throw new ValidationException($"File size exceeds the limit of {maxFileSizeMb}MB.");
                    }

                    using var memoryStream = new MemoryStream();
                    file.CopyTo(memoryStream);
                    var fileBytes = memoryStream.ToArray();

                    return singleUpload.Execute(new SingleUploadInput
                    {
                        Content = fileBytes,
                        Mimetype = file.ContentType,
                        FileName = file.FileName,
                    });
                });

        }
    }
}
