using System.Linq;
using Microsoft.EntityFrameworkCore;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Data.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly TeacherWorkoutContext _context;

        public LessonRepository(TeacherWorkoutContext context)
        {
            _context = context;
        }
        
        public PaginatedResult<Lesson> PaginatedList(LessonFilter filter)
        {
            var result = _context.Lessons.AsQueryable()
                .Include(l => l.Thumbnail)
                .Include(l => l.Theme.Thumbnail);

            return new PaginatedResult<Lesson>
            {
                TotalCount = result.Count(),
                Items = result.ToList()
            };
        }
    }
}
