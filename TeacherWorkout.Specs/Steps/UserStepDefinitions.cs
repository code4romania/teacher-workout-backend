namespace TeacherWorkout.Specs.Steps;

[Binding]
public class UserStepDefinitions(ScenarioContext scenarioContext, GraphQLServer server)
{
    [Given(@"Ion is an admin")]
    public void GivenIonIsAnAdmin()
    {
        scenarioContext["Ion"] = new TeacherWorkoutApiClient(server.Client);
    }

    [Given(@"Daniel is a user")]
    public void GivenDanielIsAUser()
    {
        scenarioContext["Daniel"] = new TeacherWorkoutApiClient(server.Client);
    }

    [Given(@"Vasile is an anonymous user")]
    public void GivenVasileIsAnAnonymousUser()
    {
        scenarioContext["Vasile"] = new TeacherWorkoutApiClient(server.Client);
    }
}
