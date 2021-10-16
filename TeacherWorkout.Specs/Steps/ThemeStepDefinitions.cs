using System.Threading.Tasks;
using FluentAssertions;
using TeacherWorkout.Specs.Extensions;
using TechTalk.SpecFlow;

namespace TeacherWorkout.Specs.Steps
{
    [Binding]
    public class ThemeStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public ThemeStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Ion creates a theme")]
        [When(@"Ion creates a theme")]
        public async Task GivenIonCreatesATheme()
        {
            _scenarioContext["theme-create-response"] = await ((TeacherWorkoutApiClient) _scenarioContext["Ion"]).ThemeCreateAsync();
        }

        [When(@"Vasile requests themes")]
        public async Task WhenVasileRequestsThemes()
        {
            _scenarioContext["themes"] = await ((TeacherWorkoutApiClient) _scenarioContext["Vasile"]).ThemesAsync();
        }

        [Then(@"Vasile receives the theme")]
        public void ThenVasileReceivesTheTheme()
        {
            _scenarioContext["themes"]
                .Should()
                .MatchResponse("Responses/Query/Themes/VisibleToVasileAsAnonymous.json");
        }

        [Then(@"the theme was created successfully")]
        public void ThenTheThemeWasCreatedSuccessfully()
        {
            _scenarioContext["theme-create-response"]
                .Should()
                .MatchResponse("Responses/Mutation/ThemeCreate/Success.json");
        }
    }
}