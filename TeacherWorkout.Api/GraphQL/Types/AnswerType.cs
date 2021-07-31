using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class AnswerType : ObjectGraphType<Answer>
    {
        public AnswerType()
        {
            Name = "Answer";
            
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Title).Description("The Title of the Answer.");
        }
    }
}