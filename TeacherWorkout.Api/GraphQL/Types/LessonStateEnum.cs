using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class LessonStateEnum : EnumerationGraphType<LessonState>
    {
        public LessonStateEnum()
        {
            Name = "LessonState";

            AddValue("Draft", "Draft state.", 1);
            AddValue("Published", "Published state.", 2);
        }
    }
}
