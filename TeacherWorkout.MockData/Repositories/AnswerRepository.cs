using System;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.MockData.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        public Answer Find(string id)
        {
            switch (id)
            {
                case "1":
                    {
                        return new Answer
                        {
                            Id = "1",
                            Title = "42"
                        };
                    }

                case "2":
                    {
                        return new Answer
                        {
                            Id = "2",
                            Title = "13"
                        };
                    }
                case "3":
                    {
                        return new Answer
                        {
                            Id = "3",
                            Title = "There is NONE"
                        };
                    }
                default:
                    throw new ArgumentException("Does not exist");
            }
        }
    }
}
