using System.Threading.Tasks;
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
        public async Task GivenIonIsAnAdmin()
        {
            var ion = new TeacherWorkoutApiClient(_server.Client);
            await ion.Register("ion");
            await ion.Login("ion");

            _scenarioContext["Ion"] = ion;
        }

        [Given(@"Vasile is an authenticated user")]
        public async Task GivenVasileIsAnAnonymousUser()
        {
            var vasile = new TeacherWorkoutApiClient(_server.Client);
            await vasile.Register("vasile");
            await vasile.Login("vasile");

            _scenarioContext["Vasile"] = vasile;
        }
    }
}