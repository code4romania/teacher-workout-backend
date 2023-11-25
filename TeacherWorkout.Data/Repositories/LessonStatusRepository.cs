using System.Collections.Generic;
using System.Linq;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Data.Repositories
{
    public class LessonStatusRepository : ILessonStatusRepository
    {
        private readonly TeacherWorkoutContext _context;

        public LessonStatusRepository(TeacherWorkoutContext context)
        {
            _context = context;
        }

        public IEnumerable<LessonStatus> List(LessonStatusFilter filter)
        {
            var lessons = new List<Lesson>();

            if (filter.LessonIds != null && filter.LessonIds.Any())
            {
                lessons = _context.Lessons.Where(l => filter.LessonIds.Contains(l.Id)).ToList();
            }
            else
            {
                lessons = _context.Lessons.ToList();
            }

            return lessons.Select(l => new LessonStatus
            {
                Lesson = l,
                CurrentLessonStep = new ExerciseStep
                {
                    Id = "42",
                    Question = "Some very important question?",
                    Answers = new List<Answer> {
                        new() {
                            Id = "42",
                            Title = "Yes"
                        },
                        new() {
                            Id = "43",
                            Title = "Awesome"
                        }
                    }
                },
                PercentCompleted = 1
            });
        }
    }
}
