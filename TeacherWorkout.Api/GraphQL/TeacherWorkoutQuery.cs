using GraphQL;
using GraphQL.Types;
using TeacherWorkout.Api.GraphQL.Types;
using TeacherWorkout.Api.GraphQL.Utils;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.FileBlobs;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Themes;

namespace TeacherWorkout.Api.GraphQL
{
    public class TeacherWorkoutQuery : ObjectGraphType<object>
    {
        public TeacherWorkoutQuery(GetThemes getThemes, 
            GetLessons getLessons,
            GetLessonStatuses getLessonStatuses,
            GetStep getStep,
            GetFileBlobs getFileBlobs)
        {
            Name = "Query";
         
            Connection<NonNullGraphType<ThemeType>>()
                .Name("themes")
                .Bidirectional()
                .Resolve(context => getThemes.Execute(context.ToInput<PaginationFilter>()).ToConnection());
            
            Connection<NonNullGraphType<LessonType>>()
                .Name("lessons")
                .Argument<IdGraphType>("themeId", "The id of the theme. Keep it null to ignore filtering.")
                .Argument<LessonStateEnum>("state", "The state of the lesson. Keep it null to ignore filtering.")
                .ReturnAll()
                .Resolve(context => getLessons.Execute(context.ToInput<LessonFilter>()).ToConnection());

            Field<NonNullGraphType<StepUnionType>>("step")
                .Argument<NonNullGraphType<IdGraphType>>(Name = "id", Description = "id of the step")
                .Resolve(context => getStep.Execute(context.ToInput<StepFindInput>()));

            Field<ListGraphType<NonNullGraphType<LessonStatusType>>>("lessonStatuses")
                .Argument<NonNullGraphType<ListGraphType<NonNullGraphType<IdGraphType>>>>(Name = "lessonIds", Description = "Id's of leassons")
                .Resolve(context => getLessonStatuses.Execute(context.ToInput<LessonStatusFilter>()));

            Field<ListGraphType<NonNullGraphType<FileBlobType>>>("recentImageUploads")
                .Argument<NonNullGraphType<IntGraphType>>("limit", "The number of recent images to return.")
                .Resolve(context => getFileBlobs.Execute(context.GetArgument<int>("limit")));
        }
    }
}

