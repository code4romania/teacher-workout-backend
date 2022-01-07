using System.Threading.Tasks;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Domain.Users
{
    public interface IUserRepository
    {
        Task InsertAsync(User user);

        Task<User> FindAsync(string email);
        Task DeleteAsync(string userEmail);
    }
}
