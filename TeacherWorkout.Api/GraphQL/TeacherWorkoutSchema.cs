using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using TeacherWorkout.Api.GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL
{
    public class TeacherWorkoutSchema : Schema
    {
        public TeacherWorkoutSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<TeacherWorkoutQuery>();
            
            RegisterTypeMapping(typeof(Image), typeof(ImageType));
        }
    }
}