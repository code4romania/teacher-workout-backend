using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class DurationUnitEnum : EnumerationGraphType<DurationUnit>
    {
        public DurationUnitEnum()
        {
            Name = "DurationUnit";
            
            AddValue("Minutes", "Minutes.", 1);
            AddValue("Hours", "Hours.", 2);
        }
    }
}