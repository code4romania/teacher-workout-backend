using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using TeacherWorkout.Data;

namespace TeacherWorkout.Specs.Hooks;

[Binding]
public class DatabaseHooks(ScenarioContext scenarioContext, GraphQLServer server)
{
    [BeforeScenario]
    public void BeforeScenario()
    {
        var dbContext = server.Factory.Services.GetService<TeacherWorkoutContext>();
        var transaction = dbContext.Database.BeginTransaction();

        scenarioContext["transaction"] = transaction;
        scenarioContext["dbContext"] = dbContext;
    }

    [AfterScenario]
    public void AfterScenario()
    {
        ((IDbContextTransaction)scenarioContext["transaction"]).Rollback();
    }
}
