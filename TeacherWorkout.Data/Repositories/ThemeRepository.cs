using System.Linq;
using Microsoft.EntityFrameworkCore;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Themes;

namespace TeacherWorkout.Data.Repositories
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly TeacherWorkoutContext _context;

        public ThemeRepository(TeacherWorkoutContext context)
        {
            _context = context;
        }

        public PaginatedResult<Theme> PaginatedList(PaginationFilter pagination)
        {
            var result = _context.Themes.AsQueryable()
                .Include(t => t.Thumbnail);

            return new PaginatedResult<Theme>
            {
                TotalCount = result.Count(),
                Items = result.ToList()
            };
        }

        public void Insert(Theme theme)
        {
            _context.Themes.Add(theme);
            _context.SaveChanges();
        }
    }
}
