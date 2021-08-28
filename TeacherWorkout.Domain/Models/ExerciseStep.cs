using System.Collections.Generic;

namespace TeacherWorkout.Domain.Models
{
    public class ExerciseStep : ILessonStep
    {
        public string Id { get; set; }

        public string Question { get; set; }

        public IEnumerable<Answer> Answers { get; set; }

        public Lesson Lesson { get; set; }
    }
}