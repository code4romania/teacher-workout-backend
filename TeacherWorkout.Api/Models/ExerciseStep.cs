using System.Collections.Generic;

namespace TeacherWorkout.Api.Models
{
    public class ExerciseStep : ILessonStep
    {
        public string Question { get; set; }

        public IEnumerable<Answer> Answers { get; set; }
        public string Id { get; set; }
    }
}