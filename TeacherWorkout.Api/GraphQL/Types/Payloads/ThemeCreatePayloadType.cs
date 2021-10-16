using GraphQL.Types;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Api.GraphQL.Types.Payloads
{
    public class ThemeCreatePayloadType : ObjectGraphType<ThemeCreatePayload>
    {
        public ThemeCreatePayloadType()
        {
            Name = "ThemeCreatePayload";

            Field(x => x.Theme).Description("The Theme.");
        }
    }
}
