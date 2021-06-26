using System;
using System.Collections.Generic;
using GraphQL;
using GraphQL.Types;
using TeacherWorkout.Api.GraphQL.Resolvers;
using TeacherWorkout.Api.GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL
{
    public class TeacherWorkoutQuery : ObjectGraphType<object>
    {
        public TeacherWorkoutQuery()
        {
            Name = "Query";
            
            Field<ListGraphType<ThemeType>>(
                "themes",
                resolve: context =>
                {
                    return new[]
                    {
                        new Theme
                        {
                            Id = "1",
                            Title = "Lorem Ipsum",
                            Thumbnail = new Image
                            {
                                Description = "Cat Photo",
                                Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                            }
                        }
                    };
                });
            
            Field<ListGraphType<LessonType>>(
                "lessons",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "themeId", Description = "id of the Theme" }
                ),
                resolve: context =>
                {
                    return new[]
                    {
                        new Lesson
                        {
                            Id = "1",
                            Title = "Lorem Ipsum",
                            Thumbnail = new Image
                            {
                                Description = "Cat Photo",
                                Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"

                            },
                            Theme = new Theme
                            {
                                Id = "1",
                                Title = "Lorem Ipsum",
                                Thumbnail = new Image
                                {
                                    Description = "Cat Photo",
                                    Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                                }
                            },
                            Duration = new Duration
                            {
                                Value = 45,
                                Unit = DurationUnit.Minutes
                            }
                        }
                    };
                });

            Field<StepUnionType>(
                "step",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> {Name = "id", Description = "id of the step"}
                ),
                resolve: context =>
                {
                    var stepId = context.GetArgument<string>("id");
                    return StepCompleteResolver.MockStepComplete(stepId);
                });
                
        }
    }
}