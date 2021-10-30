using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models.Inputs;

namespace TeacherWorkout.Domain.Lessons
{
    public class StepSubmitAnswerInputValidator : IValidator<StepSubmitAnswerInput>
    {
        private readonly IStepRepository _stepRepository;
        private readonly IAnswerRepository _answerRepository;

        public StepSubmitAnswerInputValidator(IStepRepository stepRepository, IAnswerRepository answerRepository)
        {
            _stepRepository = stepRepository;
            _answerRepository = answerRepository;
        }

        public bool IsValid(StepSubmitAnswerInput input)
        {
            var step = _stepRepository.Find(input.StepId);

            if (step == null)
            {
                return false; 
            }

            foreach (var answerId in input.AnswerIds)
            {
                var answer = _answerRepository.Find(answerId);

                if (answer == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
