namespace TeacherWorkout.Specs.Steps;

[Binding]
public class LessonStepDefinitions(ScenarioContext scenarioContext)
{
    [When(@"Daniel requests lessons")]
    public async Task WhenDanielRequestsLessons()
    {
        scenarioContext["lessons"] = await ((TeacherWorkoutApiClient)scenarioContext["Daniel"]).LessonsAsync();
    }

    [Then(@"Daniel receives the lessons")]
    public void ThenDanielReceivesTheLesson()
    {
        scenarioContext["lessons"]
            .Should()
            .MatchResponse("Responses/Query/Lessons/VisibleToDanielAsUser.json");
    }

    [When(@"Daniel searches a lesson")]
    public async Task WhenDanielSearchesForLessons()
    {
        scenarioContext["lessons"] = await ((TeacherWorkoutApiClient)scenarioContext["Daniel"]).SearchLessonByTitleAsync();
    }

    [Then(@"Daniel receives the searched lesson")]
    public void ThenDanielReceivesTheSearchedLesson()
    {
        scenarioContext["lessons"]
            .Should()
            .MatchResponse("Responses/Query/Lessons/DanielSearchedForALesson.json");
    }
}
