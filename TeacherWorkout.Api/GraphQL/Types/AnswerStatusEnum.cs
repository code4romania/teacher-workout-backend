using GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class AnswerStatusEnum : EnumerationGraphType<AnswerStatus>
    {
        public AnswerStatusEnum()
        {
            Name = "AnswerStatus";
            
            AddValue("Correct", "Correct.", 1);
            AddValue("Incorrect", "Incorrect.", 2);
            AddValue("None", "None.", 3);
        }
    }
}