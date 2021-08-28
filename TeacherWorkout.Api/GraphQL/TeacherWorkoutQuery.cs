using GraphQL.Types;
using TeacherWorkout.Api.GraphQL.Types;
using TeacherWorkout.Api.GraphQL.Utils;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Themes;

namespace TeacherWorkout.Api.GraphQL
{
    public class TeacherWorkoutQuery : ObjectGraphType<object>
    {
        public TeacherWorkoutQuery(GetThemes getThemes, 
            GetLessons getLessons,
            GetLessonStatuses getLessonStatuses,
            GetStep getStep)
        {
            Name = "Query";
         
            Connection<NonNullGraphType<ThemeType>>()
                .Name("themes")
                .Bidirectional()
                .Resolve(context => getThemes.Execute(context.ToInput<PaginationFilter>()).ToConnection());
            
            Connection<NonNullGraphType<LessonType>>()
                .Name("lessons")
                .Argument<IdGraphType>("themeId", "The id of the theme. Keep it null to ignore filtering.")
                .ReturnAll()
                .Resolve(context => getLessons.Execute(context.ToInput<LessonFilter>()).ToConnection());

            Field<NonNullGraphType<StepUnionType>>(
                "step",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "id", Description = "id of the step"}
                ),
                resolve: context => getStep.Execute(context.ToInput<StepFindInput>()));
                
            Field<ListGraphType<NonNullGraphType<LessonStatusType>>>(
                "lessonStatuses",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<NonNullGraphType<IdGraphType>>>> { Name = "lessonIds", Description = "Ids of " }
                ),
                resolve: context => getLessonStatuses.Execute(context.ToInput<LessonStatusFilter>()));
        }
    }
}

