using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class AnswerStatusEnum : EnumerationGraphType<AnswerStatus>
    {
        public AnswerStatusEnum()
        {
            Name = "AnswerStatus";
            
            Add("Correct", AnswerStatus.Correct);
            Add("Incorrect", AnswerStatus.Incorrect);
            Add("None", AnswerStatus.None);
        }
    }
}