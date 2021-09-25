using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Payloads;
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
            ((Result<PaginatedResult<Theme>>) _scenarioContext["themes"])
                .Data.Should().NotBeNull();
            ((Result<PaginatedResult<Theme>>) _scenarioContext["themes"])
                .Data.Items.Count().Should().Be(1);
        }

        [Then(@"the theme was created successfully")]
        public void ThenTheThemeWasCreatedSuccessfully()
        {
            var result = (Result<ThemeCreatePayload>) _scenarioContext["theme-create-response"];
            result.Errors.Should().BeNull();
            result.Data.Theme.Id.Should().NotBeNull();
        }
    }
}