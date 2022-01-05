using Microsoft.AspNetCore.Identity;

namespace TeacherWorkout.Identity.Services
{
    public interface IJwtService
    {
        string GenerateToken(IdentityUser user);
    }
}