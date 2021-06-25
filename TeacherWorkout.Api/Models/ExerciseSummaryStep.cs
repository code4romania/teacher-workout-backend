using System.Collections.Generic;

namespace TeacherWorkout.Api.Models
{
    public class ExerciseSummaryStep : ILessonStep
    {
        public string Id { get; set; }

        public IEnumerator<AnswerResult> Results { get; set; }
    }
}