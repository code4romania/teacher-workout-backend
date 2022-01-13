using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using TeacherWorkout.Data;
using TechTalk.SpecFlow;

namespace TeacherWorkout.Specs.Hooks
{
    [Binding]
    public class DatabaseHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly GraphQLServer _server;

        public DatabaseHooks(ScenarioContext scenarioContext, GraphQLServer server)
        {
            _scenarioContext = scenarioContext;
            _server = server;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var dbContext = _server.Factory.Services.GetRequiredService<TeacherWorkoutContext>();
            var transaction = dbContext.Database.BeginTransaction();

            _scenarioContext["transaction"] = transaction;
            _scenarioContext["dbContext"] = dbContext;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            ((IDbContextTransaction)_scenarioContext["transaction"]).Rollback();
        }
    }
}