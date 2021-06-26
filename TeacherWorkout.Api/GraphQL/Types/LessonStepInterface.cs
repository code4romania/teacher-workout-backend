using System;
using GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class LessonStepInterface : InterfaceGraphType<ILessonStep>
    {
        public LessonStepInterface(
            SlideStepType slideStep,
            ExerciseStepType exerciseStep,
            ExerciseSummaryStepType exerciseSummaryStep,
            LessonSummaryStepType lessonSummaryStep)
        {
            Name = "LessonStep";

            Field(d => d.Id, type: typeof(IdGraphType)).Description("The id of the step.");
            ResolveType = obj =>
            {
                if (obj is SlideStep)
                {
                    return slideStep;
                }

                if (obj is ExerciseStep)
                {
                    return exerciseStep;
                }

                if (obj is ExerciseSummaryStep)
                {
                    return exerciseSummaryStep;
                }

                if (obj is LessonSummaryStep)
                {
                    return lessonSummaryStep;
                }

                throw new ArgumentOutOfRangeException($"Could not resolve graph type for {obj.GetType().Name}");
            };
            
        }
    }
}