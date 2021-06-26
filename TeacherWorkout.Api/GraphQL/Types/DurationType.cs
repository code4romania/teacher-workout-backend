using GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class DurationType : ObjectGraphType<Duration>
    {
        public DurationType()
        {
            Name = "Duration";

            Field(x => x.Value).Description("The amount.");
            Field(x => x.Unit).Description("The Unit of the amount.");
            Field(x => x.DisplayValue).Description("Formatted duration.");
        }
    }
}