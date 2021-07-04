using System;
using System.Collections.Generic;
using System.Linq;
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
            
            Field<ListGraphType<NonNullGraphType<ThemeType>>>(
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
            
            Field<ListGraphType<NonNullGraphType<LessonType>>>(
                "lessons",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "themeId", Description = "id of the Theme" }
                ),
                resolve: context => { return new[] {Lesson.BuildMock()}; });

            Field<NonNullGraphType<StepUnionType>>(
                "step",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "id", Description = "id of the step"}
                ),
                resolve: context =>
                {
                    var stepId = context.GetArgument<string>("id");
                    return StepCompleteResolver.MockStep(stepId);
                });
                
            Field<ListGraphType<NonNullGraphType<LessonStatusType>>>(
                "lessonStatuses",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<NonNullGraphType<IdGraphType>>>> { Name = "lessonIds", Description = "Ids of " }
                ),
                resolve: context =>
                {
                    return context.GetArgument<IEnumerable<string>>("lessonIds")
                        .Select(lessonId => new LessonStatus
                        {
                            Lesson = Lesson.BuildMock(lessonId),
                            PercentCompleted = 10,
                            CurrentLessonStep = new SlideStep
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
                });
        }
    }
}