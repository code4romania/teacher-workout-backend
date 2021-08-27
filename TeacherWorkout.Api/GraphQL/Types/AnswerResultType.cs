using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class AnswerResultType : ObjectGraphType<AnswerResult>
    {
        public AnswerResultType()
        {
            Name = "AnswerResult";
            
            Field(x => x.Answer).Description("The actual answer.");
            Field(x => x.Status).Description("The outcome for the answer.");
        }
    }
}