using System;
using GraphQL.Types;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class LessonStepInterface : InterfaceGraphType<ILessonStep>
    {
        public LessonStepInterface()
        {
            Name = "LessonStep";

            Field(d => d.Id, type: typeof(IdGraphType)).Description("The id of the step.");

            // Note: be sure not to pull in these references from DI when the graph types
            // are registered as transients (the default lifetime for graph types)
            // https://github.com/graphql-dotnet/graphql-dotnet/blob/master/docs2/site/docs/getting-started/interfaces.md#resolvetype
            ResolveType = obj =>
            {
                if (obj is SlideStep)
                {
                    return new GraphQLTypeReference("SlideStep");
                }

                if (obj is ExerciseStep)
                {
                    return new GraphQLTypeReference("ExerciseStep");
                }

                if (obj is ExerciseSummaryStep)
                {
                    return new GraphQLTypeReference("ExerciseSummaryStep");
                }

                if (obj is LessonSummaryStep)
                {
                    return new GraphQLTypeReference("LessonSummaryStep");
                }

                throw new ArgumentOutOfRangeException($"Could not resolve graph type for {obj.GetType().Name}");
            };
            
        }
    }
}