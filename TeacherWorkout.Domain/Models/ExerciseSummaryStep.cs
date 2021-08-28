using System.Collections.Generic;

namespace TeacherWorkout.Domain.Models
{
    public class ExerciseSummaryStep : ILessonStep
    {
        public string Id { get; set; }

        public IEnumerable<AnswerResult> Results { get; set; }

        public Lesson Lesson { get; set; }
    }
}