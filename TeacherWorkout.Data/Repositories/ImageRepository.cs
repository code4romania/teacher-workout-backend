using System.Linq;
using TeacherWorkout.Domain.Images;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Data.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly TeacherWorkoutContext _context;

        public ImageRepository(TeacherWorkoutContext context)
        {
            _context = context;
        }

        public Image Find(string id)
        {
            return _context.Images.FirstOrDefault(i => i.Id == id);
        }
    }
}
