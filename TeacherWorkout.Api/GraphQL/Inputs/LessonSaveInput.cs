using GraphQL.Types;

namespace TeacherWorkout.Api.GraphQL.Inputs
{
    public class LessonSaveInput : InputObjectGraphType
    {
        public LessonSaveInput()
        {
            Name = "LessonSaveInput";
            Field<IdGraphType>("lessonId");
        }
    }
}