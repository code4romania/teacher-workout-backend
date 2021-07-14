using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using GraphQL.Types.Relay.DataObjects;
using TeacherWorkout.Api.GraphQL.Types;
using TeacherWorkout.Api.GraphQL.Utils;
using TeacherWorkout.Api.Models;

namespace TeacherWorkout.Api.GraphQL
{
    public class TeacherWorkoutQuery : ObjectGraphType<object>
    {
        public TeacherWorkoutQuery()
        {
            Name = "Query";
         
            Connection<NonNullGraphType<ThemeType>>()
                .Name("themes")
                .Bidirectional()
                .Resolve(_ => new List<Theme>
                {
                    new()
                    {
                        Id = "1",
                        Title = "Lorem Ipsum",
                        Thumbnail = new Image
                        {
                            Description = "Cat Photo",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                        }
                    },
                    new()
                    {
                        Id = "2",
                        Title = "Dolor sit amet",
                        Thumbnail = new Image
                        {
                            Description = "Another Cat Photo",
                            Url = "https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg"
                        }
                    },
                    new()
                    {
                        Id = "3",
                        Title = "Consectetur adipiscing elit",
                        Thumbnail = new Image
                        {
                            Description = "YACP",
                            Url = "http://cdn.shopify.com/s/files/1/1149/5008/articles/why-cat-looking-at-wall-or-nothing.jpg?v=1551321728"
                        }
                    },
                    new()
                    {
                        Id = "4",
                        Title = "Fusce tempor",
                        Thumbnail = new Image
                        {
                            Description = "More Cat Photos",
                            Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcReLDHsAIhgLgFpupyZg0CtevFcI2NY9WkoOQ&usqp=CAU"
                        }
                    },
                    new()
                    {
                        Id = "5",
                        Title = "Doloremque laudantium",
                        Thumbnail = new Image
                        {
                            Description = "Dog Photos",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/e/e6/10_years_old_american_staff.jpg"
                        }
                    },
                    new()
                    {
                        Id = "6",
                        Title = "Quasi architecto beatae vitae",
                        Thumbnail = new Image
                        {
                            Description = "More Dog Photos",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/f/f6/11.10.2015_Samoyed_%28cropped%29.jpg"
                        }
                    },
                    new()
                    {
                        Id = "7",
                        Title = "Nemo enim ipsam voluptatem",
                        Thumbnail = new Image
                        {
                            Description = "Cute Dog photo",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/AiredaleDog.jpg/386px-AiredaleDog.jpg"
                        }
                    },
                    new()
                    {
                        Id = "8",
                        Title = "Sed quia consequuntur magni dolores eos",
                        Thumbnail = new Image
                        {
                            Description = "Nice dog photo",
                            Url = "https://commons.wikimedia.org/wiki/Category:Sitting_dogs#/media/File:Cachorro_ra%C3%A7a_Lhasa_Apso_posando_para_book_canino_perfil.JPG"
                        }
                    },
                    new()
                    {
                        Id = "9",
                        Title = "Ratione voluptatem sequi nesciunt",
                        Thumbnail = new Image
                        {
                            Description = "Very nice dog photo",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/9/9a/Paisible.JPG"
                        }
                    },
                    new()
                    {
                        Id = "10",
                        Title = "Neque porro quisquam est",
                        Thumbnail = new Image
                        {
                            Description = "Small dog photo",
                            Url = "https://commons.wikimedia.org/wiki/Category:Dogs_tilting_head#/media/File:Yumi_19mois2.jpg"
                        }
                    },
                    new()
                    {
                        Id = "11",
                        Title = "Accusamus et iusto",
                        Thumbnail = new Image
                        {
                            Description = "Beautiful dog photo",
                            Url = "https://commons.wikimedia.org/wiki/Category:Quality_images_of_dogs#/media/File:Canis_lupus_PO.jpg"
                        }
                    }
                }.ToConnection());
            
            Connection<NonNullGraphType<LessonType>>()
                .Name("lessons")
                .Argument<NonNullGraphType<IdGraphType>>("themeId", "id of the Theme")
                .ReturnAll()
                .Resolve(_ => new List<Lesson>
                {
                    new()
                    {
                        Id = "1",
                        Title = "Lorem Ipsum",
                        Thumbnail = new Image
                        {
                            Description = "Cat Photo",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"

                        },
                        Theme = new Theme
                        {
                            Id = "1",
                            Title = "Lorem Ipsum",
                            Thumbnail = new Image
                            {
                                Description = "Cat Photo",
                                Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                            }
                        },
                        Duration = new Duration
                        {
                            Value = 45,
                            Unit = DurationUnit.Minutes
                        }
                    },
                    new()
                    {
                        Id = "2",
                        Title = "Dolor sit amet",
                        Thumbnail = new Image
                        {
                            Description = "Another Cat Photo",
                            Url = "https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg"
                        },
                        Theme = new Theme
                        {
                            Id = "1",
                            Title = "Lorem Ipsum",
                            Thumbnail = new Image
                            {
                                Description = "Cat Photo",
                                Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                            }
                        },
                        Duration = new Duration
                        {
                            Value = 32,
                            Unit = DurationUnit.Minutes
                        }
                    },
                    new()
                    {
                        Id = "3",
                        Title = "Consectetur adipiscing elit",
                        Thumbnail = new Image
                        {
                            Description = "YACP",
                            Url = "http://cdn.shopify.com/s/files/1/1149/5008/articles/why-cat-looking-at-wall-or-nothing.jpg?v=1551321728"
                        },
                        Theme = new Theme
                        {
                            Id = "1",
                            Title = "Lorem Ipsum",
                            Thumbnail = new Image
                            {
                                Description = "Cat Photo",
                                Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                            }
                        },
                        Duration = new Duration
                        {
                            Value = 55,
                            Unit = DurationUnit.Minutes
                        }
                    },
                    new()
                    {
                        Id = "4",
                        Title = "Fusce tempor",
                        Thumbnail = new Image
                        {
                            Description = "More Cat Photos",
                            Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcReLDHsAIhgLgFpupyZg0CtevFcI2NY9WkoOQ&usqp=CAU"
                        },
                        Theme = new Theme
                        {
                            Id = "1",
                            Title = "Lorem Ipsum",
                            Thumbnail = new Image
                            {
                                Description = "Cat Photo",
                                Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                            }
                        },
                        Duration = new Duration
                        {
                            Value = 37,
                            Unit = DurationUnit.Minutes
                        }
                    },
                    new()
                    {
                        Id = "5",
                        Title = "Doloremque laudantium",
                        Thumbnail = new Image
                        {
                            Description = "Dog Photos",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/e/e6/10_years_old_american_staff.jpg"
                        },
                        Theme = new Theme
                        {
                            Id = "7",
                            Title = "Nemo enim ipsam voluptatem",
                            Thumbnail = new Image
                            {
                                Description = "Cute Dog photo",
                                Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/AiredaleDog.jpg/386px-AiredaleDog.jpg"
                            }
                        },
                        Duration = new Duration
                        {
                            Value = 39,
                            Unit = DurationUnit.Minutes
                        }
                    },
                    new()
                    {
                        Id = "6",
                        Title = "Quasi architecto beatae vitae",
                        Thumbnail = new Image
                        {
                            Description = "More Dog Photos",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/f/f6/11.10.2015_Samoyed_%28cropped%29.jpg"
                        },
                        Theme = new Theme
                        {
                            Id = "8",
                            Title = "Sed quia consequuntur magni dolores eos",
                            Thumbnail = new Image
                            {
                                Description = "Nice dog photo",
                                Url = "https://commons.wikimedia.org/wiki/Category:Sitting_dogs#/media/File:Cachorro_ra%C3%A7a_Lhasa_Apso_posando_para_book_canino_perfil.JPG"
                            }
                        },
                        Duration = new Duration
                        {
                            Value = 42,
                            Unit = DurationUnit.Minutes
                        }
                    },
                    new()
                    {
                        Id = "7",
                        Title = "Nemo enim ipsam voluptatem",
                        Thumbnail = new Image
                        {
                            Description = "Cute Dog photo",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/43/AiredaleDog.jpg/386px-AiredaleDog.jpg"
                        },
                        Theme = new Theme
                        {
                            Id = "9",
                            Title = "Ratione voluptatem sequi nesciunt",
                            Thumbnail = new Image
                            {
                                Description = "Very nice dog photo",
                                Url = "https://upload.wikimedia.org/wikipedia/commons/9/9a/Paisible.JPG"
                            }
                        },
                        Duration = new Duration
                        {
                            Value = 45,
                            Unit = DurationUnit.Minutes
                        }
                    },
                    new()
                    {
                        Id = "8",
                        Title = "Sed quia consequuntur magni dolores eos",
                        Thumbnail = new Image
                        {
                            Description = "Nice dog photo",
                            Url = "https://commons.wikimedia.org/wiki/Category:Sitting_dogs#/media/File:Cachorro_ra%C3%A7a_Lhasa_Apso_posando_para_book_canino_perfil.JPG"
                        },
                        Theme = new Theme
                        {
                            Id = "10",
                            Title = "Neque porro quisquam est",
                            Thumbnail = new Image
                            {
                                Description = "Small dog photo",
                                Url = "https://commons.wikimedia.org/wiki/Category:Dogs_tilting_head#/media/File:Yumi_19mois2.jpg"
                            }
                        },
                        Duration = new Duration
                        {
                            Value = 44,
                            Unit = DurationUnit.Minutes
                        }
                    },
                    new()
                    {
                        Id = "9",
                        Title = "Ratione voluptatem sequi nesciunt",
                        Thumbnail = new Image
                        {
                            Description = "Very nice dog photo",
                            Url = "https://upload.wikimedia.org/wikipedia/commons/9/9a/Paisible.JPG"
                        },
                        Theme = new Theme
                        {
                            Id = "11",
                            Title = "Accusamus et iusto",
                            Thumbnail = new Image
                            {
                                Description = "Beautiful dog photo",
                                Url = "https://commons.wikimedia.org/wiki/Category:Quality_images_of_dogs#/media/File:Canis_lupus_PO.jpg"
                            }
                        },
                        Duration = new Duration
                        {
                            Value = 43,
                            Unit = DurationUnit.Minutes
                        }
                    },
                    new()
                    {
                        Id = "10",
                        Title = "Neque porro quisquam est",
                        Thumbnail = new Image
                        {
                            Description = "Small dog photo",
                            Url = "https://commons.wikimedia.org/wiki/Category:Dogs_tilting_head#/media/File:Yumi_19mois2.jpg"
                        },
                        Theme = new Theme
                        {
                            Id = "5",
                            Title = "Doloremque laudantium",
                            Thumbnail = new Image
                            {
                                Description = "Dog Photos",
                                Url = "https://upload.wikimedia.org/wikipedia/commons/e/e6/10_years_old_american_staff.jpg"
                            }
                        },
                        Duration = new Duration
                        {
                            Value = 46,
                            Unit = DurationUnit.Minutes
                        }
                    },
                    new()
                    {
                        Id = "11",
                        Title = "Accusamus et iusto",
                        Thumbnail = new Image
                        {
                            Description = "Beautiful dog photo",
                            Url = "https://commons.wikimedia.org/wiki/Category:Quality_images_of_dogs#/media/File:Canis_lupus_PO.jpg"
                        },
                        Theme = new Theme
                        {
                            Id = "6",
                            Title = "Quasi architecto beatae vitae",
                            Thumbnail = new Image
                            {
                                Description = "More Dog Photos",
                                Url = "https://upload.wikimedia.org/wikipedia/commons/f/f6/11.10.2015_Samoyed_%28cropped%29.jpg"
                            }
                        },
                        Duration = new Duration
                        {
                            Value = 49,
                            Unit = DurationUnit.Minutes
                        }
                    }
                }.ToConnection());

            Field<NonNullGraphType<StepUnionType>>(
                "step",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "id", Description = "id of the step"}
                ),
                resolve: context =>
                {
                    switch (context.GetArgument<string>("id"))
                    {
                        case "1":
                            return new SlideStep
                            {
                                Id = "1",
                                Title = "My title 1",
                                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum;",
                                Image = new Image
                                {
                                    Description = "Cat Photo",
                                    Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                                },
                                PreviousStep = null
                            };
                        case "2":
                            return new SlideStep
                            {
                                Id = "2",
                                Title = "My title 2",
                                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).",
                                Image = new Image
                                {
                                    Description = "Cat Photo",
                                    Url = "https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fstatic.onecms.io%2Fwp-content%2Fuploads%2Fsites%2F12%2F2015%2F06%2Fcrazy-cat.jpg&q=85"
                                },
                                PreviousStep = new SlideStep
                                {
                                    Id = "1",
                                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum;",
                                    Image = new Image
                                    {
                                        Description = "Cat Photo",
                                           Url = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ficatcare.org%2F&psig=AOvVaw0nBkNYvmgGLHcuursLSpxE&ust=1624782643255000&source=images&cd=vfe&ved=0CAoQjRxqFwoTCJCJqI3ytPECFQAAAAAdAAAAABAJ"
                                    },
                                    PreviousStep = null
                                }
                            };
                        case "3":
                            return new ExerciseStep
                            {
                                Id = "3",
                                Question = "What is the meaning of life, universe and everything?",
                                Answers = new []
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
                                Description = "There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which don't look even slightly believable. If you are going to use a passage of Lorem Ipsum, you need to be sure there isn't anything embarrassing hidden in the middle of text. All the Lorem Ipsum generators on the Internet tend to repeat predefined chunks as necessary, making this the first true generator on the Internet.",
                                Image = new Image
                                {
                                    Description = "Cat Photo",
                                    Url = "https://www.google.com/url?sa=i&url=https%3A%2F%2Ficatcare.org%2F&psig=AOvVaw0nBkNYvmgGLHcuursLSpxE&ust=1624782643255000&source=images&cd=vfe&ved=0CAoQjRxqFwoTCJCJqI3ytPECFQAAAAAdAAAAABAJ"
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
                    };
                });
                
            Field<ListGraphType<NonNullGraphType<LessonStatusType>>>(
                "lessonStatuses",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<NonNullGraphType<IdGraphType>>>> { Name = "lessonIds", Description = "Ids of " }
                ),
                resolve: context =>
                {
                    return context.GetArgument<IEnumerable<string>>("lessonIds")
                        .Select(lessonId => new LessonStatus
                        {
                            Lesson = new Lesson
                            {
                                Id = lessonId,
                                Title = "Lorem Ipsum",
                                Thumbnail = new Image
                                {
                                    Description = "Cat Photo",
                                    Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"

                                },
                                Theme = new Theme
                                {
                                    Id = "1",
                                    Title = "Lorem Ipsum",
                                    Thumbnail = new Image
                                    {
                                        Description = "Cat Photo",
                                        Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                                    }
                                },
                                Duration = new Duration
                                {
                                    Value = 45,
                                    Unit = DurationUnit.Minutes
                                }
                            },
                            PercentCompleted = 10,
                            CurrentLessonStep = new SlideStep
                            {
                                Id = "1",
                                Title = "My title 1",
                                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum;",
                                Image = new Image
                                {
                                    Description = "Cat Photo",
                                    Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b6/Felis_catus-cat_on_snow.jpg/640px-Felis_catus-cat_on_snow.jpg"
                                },
                                PreviousStep = null
                            }
                        });
                });
        }
    }
}