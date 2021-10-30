using System;
using System.Collections.Generic;
using System.Linq;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Domain.Lessons
{
    public class SubmitAnswer : IOperation<StepSubmitAnswerInput, StepSubmitAnswerPayload>
    {
        private readonly IStepRepository _stepRepository;
        private readonly ILessonStatusRepository _lessonStatusRepository;
        private readonly StepSubmitAnswerInputValidator _validator;

        public SubmitAnswer(IStepRepository stepRepository, ILessonStatusRepository lessonStatusRepository, StepSubmitAnswerInputValidator validator)
        {
            _stepRepository = stepRepository;
            _lessonStatusRepository = lessonStatusRepository;
            _validator = validator;
        }

        public StepSubmitAnswerPayload Execute(StepSubmitAnswerInput input)
        {
            if (!_validator.IsValid(input))
            {
                throw new ArgumentException("Input is not valid");
            }

            var step = _stepRepository.SubmitAnswer(input.StepId, input.AnswerIds);
            var lessonId = (step.GetType().GetProperty("Lesson").GetValue(step) as Lesson).Id;

            var lessonStatus = _lessonStatusRepository
                .List(
                new LessonStatusFilter()
                {
                    LessonIds = new List<string>() { lessonId }
                })
                .FirstOrDefault();

            return new StepSubmitAnswerPayload()
            {
                Step = step,
                LessonStatus = lessonStatus
            };
        }
    }
}
