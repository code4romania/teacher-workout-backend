using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TeacherWorkout.Identity.Services
{
    public interface IJwtService
    {
        string GenerateToken(IdentityUser user, IList<string> userRoles);
    }
}