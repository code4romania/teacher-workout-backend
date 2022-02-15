using GraphQL.Types;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Api.GraphQL.Types.Payloads
{
    public class ThemeUpdatePayloadType : ObjectGraphType<ThemeUpdatePayload>
    {
        public ThemeUpdatePayloadType()
        {
            Name = "ThemeUpdatePayload";

            Field(x => x.Theme).Description("The Theme.");
        }
    }
}
