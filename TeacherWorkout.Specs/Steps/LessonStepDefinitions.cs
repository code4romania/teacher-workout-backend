namespace TeacherWorkout.Specs.Steps;

[Binding]
public class LessonStepDefinitions(ScenarioContext scenarioContext)
{
    [Given(@"Ion is an admin")]
    [When(@"Ion saves a lesson")]
    public async Task GivenIonCreatesALesson()
    {
        scenarioContext["lesson-save-response"] = await ((TeacherWorkoutApiClient)scenarioContext["Ion"]).LessonCreateAsync();
    }

    [Then(@"the lesson was saved successfully")]
    public void ThenTheLessonWasCreatedSuccessfully()
    {
        scenarioContext["lesson-save-response"]
            .Should()
            .MatchResponse("Responses/Mutation/LessonSave/Success.json");
    }
}
