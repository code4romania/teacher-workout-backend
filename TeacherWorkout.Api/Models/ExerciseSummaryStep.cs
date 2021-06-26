using System.Collections.Generic;

namespace TeacherWorkout.Api.Models
{
    public class ExerciseSummaryStep : ILessonStep
    {
        public IEnumerable<AnswerResult> Results { get; set; }
        public string Id { get; set; }
    }
}