using System.Collections.Generic;

namespace TeacherWorkout.Domain.Models.Inputs
{
    public class StepSubmitAnswerInput
    {
        public string StepId { get; set; }

        public IEnumerable<string> AnswerIds { get; set; }

    }
}
