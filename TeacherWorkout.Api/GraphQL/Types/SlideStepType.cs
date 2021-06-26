using GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL.Types
{
    public class SlideStepType : ObjectGraphType<SlideStep>
    {
        public SlideStepType()
        {
            Name = "SlideStep";

            Interface<LessonStepInterface>();
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Title).Description("The Lesson Title");
            Field(x => x.Description).Description("The Lesson Description");
            Field(x => x.Image).Description("The Lesson Image");
            Field(x => x.PreviousStep, nullable: true).Description("The Previous Step");
        }
    }
}