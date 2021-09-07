using System.Collections.Generic;
using System.Linq;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Domain.Lessons
{
    public class CompleteStep : IOperation<StepCompleteInput, StepCompletePayload>
    {
        private readonly IStepRepository _stepRepository;
        private readonly ILessonStatusRepository _lessonStatusRepository;

        public CompleteStep(IStepRepository stepRepository, ILessonStatusRepository lessonStatusRepository)
        {
            _stepRepository = stepRepository;
            _lessonStatusRepository = lessonStatusRepository;
        }

        public StepCompletePayload Execute(StepCompleteInput input)
        {
            var step = _stepRepository.CompleteStep(input.StepId);
            var lessonId = (step.GetType().GetProperty("Lesson").GetValue(step) as Lesson).Id;

            var lessonStatus = _lessonStatusRepository
                .List(
                new LessonStatusFilter()
                {
                    LessonIds = new List<string>() { lessonId }
                })
                .FirstOrDefault();

            return new StepCompletePayload()
            {
                Step = step,
                LessonStatus = lessonStatus
            };
        }
    }
}
