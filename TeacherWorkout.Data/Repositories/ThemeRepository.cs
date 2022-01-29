using System.Linq;
using Microsoft.EntityFrameworkCore;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;
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

        public Theme Find(string id)
        {
            return _context.Themes.Find(id);
        }
        
        public Theme Update(ThemeUpdateInput input)
        {
            var theme = _context.Themes.Find(input.Id);

            var thumbnailId = input.ThumbnailId ?? theme.ThumbnailId;
            theme.Title = input.Title;
            theme.Thumbnail = _context.Images.Find(thumbnailId);

            _context.SaveChanges();
            return theme;
        }
    }
}
