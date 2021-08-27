using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class LessonStatusType : ObjectGraphType<LessonStatus>
    {
        public LessonStatusType()
        {
            Name = "LessonStatus";

            Field(x => x.Lesson);
            Field(x => x.PercentCompleted);
            Field(x => x.CurrentLessonStep);
        }
    }
}