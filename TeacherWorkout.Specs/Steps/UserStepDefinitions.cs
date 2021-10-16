using TechTalk.SpecFlow;

namespace TeacherWorkout.Specs.Steps
{
    [Binding]
    public class UserStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly GraphQLServer _server;

        public UserStepDefinitions(ScenarioContext scenarioContext, GraphQLServer server)
        {
            _scenarioContext = scenarioContext;
            _server = server;
        }
        
        [Given(@"Ion is an admin")]
        public void GivenIonIsAnAdmin()
        {
            _scenarioContext["Ion"] = new TeacherWorkoutApiClient(_server.Client);
        }

        [Given(@"Vasile is an anonymous user")]
        public void GivenVasileIsAnAnonymousUser()
        {
            _scenarioContext["Vasile"] = new TeacherWorkoutApiClient(_server.Client);
        }
    }
}