using GraphQL.Types;
using TeacherWorkout.Api.GraphQL.Types;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL
{
    public class TeacherWorkoutQuery : ObjectGraphType<object>
    {
        public TeacherWorkoutQuery()
        {
            Name = "Query";
            
            Field<ListGraphType<ThemeType>>(
                "themes",
                resolve: context =>
                {
                    return new[]
                    {
                        new Theme
                        {
                            Id = "1",
                            Title = "Lorem Ipsum",
                            Thumbnail = new Image
                            {
                                Description = "For Challenged People",
                                Url = "https://example.com"
                            }
                        }
                    };
                });
        }
    }
}