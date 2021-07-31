using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using GraphQL.Types.Relay.DataObjects;
using TeacherWorkout.Api.GraphQL.Mock;
using TeacherWorkout.Api.GraphQL.Types;
using TeacherWorkout.Api.GraphQL.Utils;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL
{
    public class TeacherWorkoutQuery : ObjectGraphType<object>
    {
        public TeacherWorkoutQuery()
        {
            Name = "Query";

            Connection<NonNullGraphType<ThemeType>>()
                .Name("themes")
                .Bidirectional()
                .Resolve(_ => ThemeFactory.MakeMany().ToConnection());

            Connection<NonNullGraphType<LessonType>>()
                .Name("lessons")
                .Argument<NonNullGraphType<IdGraphType>>("themeId", "id of the Theme")
                .ReturnAll()
                .Resolve(_ => LessonFactory.MakeMany().ToConnection());

            Field<NonNullGraphType<StepUnionType>>(
                "step",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                    { Name = "id", Description = "id of the step" }),
                resolve: StepFactory.Make);

            Field<ListGraphType<NonNullGraphType<LessonStatusType>>>(
                "lessonStatuses",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<NonNullGraphType<IdGraphType>>>>
                        { Name = "lessonIds", Description = "Ids of " }
                ),
                resolve: LessonStatusFactory.Make);
        }
    }
}
