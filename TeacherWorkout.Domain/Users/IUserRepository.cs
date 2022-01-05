using System.Threading.Tasks;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Users
{
    public interface IUserRepository
    {
        Task Insert(User user);

        Task<User> Find(string email);
    }
}
