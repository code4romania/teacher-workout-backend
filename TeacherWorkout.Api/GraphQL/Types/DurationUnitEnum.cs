using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class DurationUnitEnum : EnumerationGraphType<DurationUnit>
    {
        public DurationUnitEnum()
        {
            Name = "DurationUnit";
            
            Add("Minutes", DurationUnit.Minutes);
            Add("Hours", DurationUnit.Hours);
        }
    }
}