using System;
using System.Collections.Generic;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.MockData.Repositories
{
    public class StepRepository : IStepRepository
    {
        public ILessonStep CompleteStep(string id)
        {
            switch (id)
            {
                case "1":
                    return new SlideStep
                    {
                        Id = "1",
                        Title = "My title 1",
                        Description =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum;",
                        Image = new Image
                        {
                            Description = "Cat Photo",
                            Url =
                            "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                        },
                        PreviousStep = null,
                        Lesson = new Lesson()
                        {
                            Id = "1"
                        }
                    };
                case "2":
                    return new SlideStep
                    {
                        Id = "2",
                        Title = "My title 2",
                        Description =
                                                "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                        Image = new Image
                        {
                            Description = "Cat Photo",
                            Url =
                                                    "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F12%2F2015%2F06%2Fcrazy-cat.jpg&q=85"
                        },
                        PreviousStep = new SlideStep
                        {
                            Id = "1",
                            Description =
                                                    "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum;",
                            Image = new Image
                            {
                                Description = "Cat Photo",
                                Url =
                                                        "https://www.google.com/url?sa=i&url=https%3A%2F%2Ficatcare.org%2F&psig=AOvVaw0nBkNYvmgGLHcuursLSpxE&ust=1624782643255000&source=images&cd=vfe&ved=0CAoQjRxqFwoTCJCJqI3ytPECFQAAAAAdAAAAABAJ"
                            },
                            PreviousStep = null
                        },
                        Lesson = new Lesson()
                        {
                            Id = "1"
                        }
                    };
                case "3":
                    return new ExerciseStep
                    {
                        Id = "3",
                        Question = "What is the meaning of life, universe and everything?",
                        Answers = new[]
                        {
                            new Answer
                            {
                                Id = "1",
                                Title = "42"
                            },
                            new Answer
                            {
                                Id = "2",
                                Title = "13"
                            },
                            new Answer
                            {
                                Id = "3",
                                Title = "There is NONE"
                            },
                            },
                        Lesson = new Lesson()
                        {
                            Id = "1"
                        }
                    };
                case "4":
                    return new ExerciseSummaryStep
                    {
                        Id = "4",
                        Results = new List<AnswerResult>
                            {
                                new()
                                {
                                    Status = AnswerStatus.Correct,
                                    Answer = new Answer
                                    {
                                        Id = "1",
                                        Title = "42"
                                    }
                                },
                                new()
                                {
                                    Status = AnswerStatus.None,
                                    Answer = new Answer
                                    {
                                        Id = "2",
                                        Title = "13"
                                    }
                                },
                                new()
                                {
                                    Status = AnswerStatus.Incorrect,
                                    Answer = new Answer
                                    {
                                        Id = "3",
                                        Title = "There is NONE"
                                    }
                                }
                            },
                        Lesson = new Lesson()
                        {
                            Id = "1"
                        }
                    };
                case "5":
                    return new SlideStep
                    {
                        Id = "5",
                        Title = "This is my title",
                        Description =
                            "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet.",
                        Image = new Image
                        {
                            Description = "Cat Photo",
                            Url =
                                "https://www.google.com/url?sa=i&url=https%3A%2F%2Ficatcare.org%2F&psig=AOvVaw0nBkNYvmgGLHcuursLSpxE&ust=1624782643255000&source=images&cd=vfe&ved=0CAoQjRxqFwoTCJCJqI3ytPECFQAAAAAdAAAAABAJ"
                        },
                        Lesson = new Lesson()
                        {
                            Id = "1"
                        }
                    };
                case "6":
                    return new LessonSummaryStep
                    {
                        Id = "6",
                        ExperiencePoints = 100,
                        Lesson = new Lesson()
                        {
                            Id = "1"
                        }
                    };
                default:
                    throw new ArgumentException("Does not exist");
            }

        }

        public ILessonStep Find(string id)
        {
            switch (id)
            {
                case "1":
                    return new SlideStep
                    {
                        Id = "1",
                        Title = "My title 1",
                        Description =
                            "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum;",
                        Image = new Image
                        {
                            Description = "Cat Photo",
                            Url =
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                        },
                        PreviousStep = null
                    };
                case "2":
                    return new SlideStep
                    {
                        Id = "2",
                        Title = "My title 2",
                        Description =
                            "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                        Image = new Image
                        {
                            Description = "Cat Photo",
                            Url =
                                "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F12%2F2015%2F06%2Fcrazy-cat.jpg&q=85"
                        },
                        PreviousStep = new SlideStep
                        {
                            Id = "1",
                            Description =
                                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum;",
                            Image = new Image
                            {
                                Description = "Cat Photo",
                                Url =
                                    "https://www.google.com/url?sa=i&url=https%3A%2F%2Ficatcare.org%2F&psig=AOvVaw0nBkNYvmgGLHcuursLSpxE&ust=1624782643255000&source=images&cd=vfe&ved=0CAoQjRxqFwoTCJCJqI3ytPECFQAAAAAdAAAAABAJ"
                            },
                            PreviousStep = null
                        }
                    };
                case "3":
                    return new ExerciseStep
                    {
                        Id = "3",
                        Question = "What is the meaning of life, universe and everything?",
                        Answers = new[]
                        {
                            new Answer
                            {
                                Id = "1",
                                Title = "42"
                            },
                            new Answer
                            {
                                Id = "2",
                                Title = "13"
                            },
                            new Answer
                            {
                                Id = "3",
                                Title = "There is NONE"
                            },
                        }
                    };
                case "4":
                    return new ExerciseSummaryStep
                    {
                        Id = "4",
                        Results = new List<AnswerResult>
                        {
                            new()
                            {
                                Status = AnswerStatus.Correct,
                                Answer = new Answer
                                {
                                    Id = "1",
                                    Title = "42"
                                }
                            },
                            new()
                            {
                                Status = AnswerStatus.None,
                                Answer = new Answer
                                {
                                    Id = "2",
                                    Title = "13"
                                }
                            },
                            new()
                            {
                                Status = AnswerStatus.Incorrect,
                                Answer = new Answer
                                {
                                    Id = "3",
                                    Title = "There is NONE"
                                }
                            }
                        }
                    };
                case "5":
                    return new SlideStep
                    {
                        Id = "5",
                        Title = "This is my title",
                        Description =
                            "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet.",
                        Image = new Image
                        {
                            Description = "Cat Photo",
                            Url =
                                "https://www.google.com/url?sa=i&url=https%3A%2F%2Ficatcare.org%2F&psig=AOvVaw0nBkNYvmgGLHcuursLSpxE&ust=1624782643255000&source=images&cd=vfe&ved=0CAoQjRxqFwoTCJCJqI3ytPECFQAAAAAdAAAAABAJ"
                        }
                    };
                case "6":
                    return new LessonSummaryStep
                    {
                        Id = "6",
                        ExperiencePoints = 100
                    };
                default:
                    throw new ArgumentException("Does not exist");
            }
        }
    }
}
