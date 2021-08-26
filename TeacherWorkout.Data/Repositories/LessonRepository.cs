﻿using System.Linq;
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
            var result = _context.Lessons.AsQueryable();

            return new PaginatedResult<Lesson>
            {
                TotalCount = result.Count(),
                Items = result.ToList()
            };
        }
    }
}