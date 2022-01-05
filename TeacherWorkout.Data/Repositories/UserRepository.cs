using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Users;

namespace TeacherWorkout.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TeacherWorkoutContext _context;

        public UserRepository(TeacherWorkoutContext context)
        {
            _context = context;
        }

        public async Task Insert(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Find(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
