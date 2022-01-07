using System.Collections.Generic;
using System.Security.Claims;

namespace TeacherWorkout.Api.GraphQL
{
    public class GraphQlUserContext : Dictionary<string, object?>
    {
        public ClaimsPrincipal User { get; set; }

        public GraphQlUserContext(ClaimsPrincipal user)
        {
            User = user;
        }
    }
}
