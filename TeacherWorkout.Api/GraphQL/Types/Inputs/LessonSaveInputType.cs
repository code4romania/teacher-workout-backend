using GraphQL.Types;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Api.GraphQL.Types.Inputs
{
    public class LessonSaveInputType : InputObjectGraphType<LessonSaveInput>
    {
        public LessonSaveInputType()
        {
            Name = "LessonSaveInput";
            
            Field(x => x.LessonId, type: typeof(NonNullGraphType<IdGraphType>));
        }
    }
}