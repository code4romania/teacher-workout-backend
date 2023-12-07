using System;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using SpecFlow.Internal.Json;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Specs.Extensions;
using TechTalk.SpecFlow;
using Xunit.Abstractions;

namespace TeacherWorkout.Specs.Steps
{
    [Binding]
    public class ThemeStepDefinitions(ScenarioContext scenarioContext)
    {
        private readonly ScenarioContext _scenarioContext = scenarioContext;

        [Given(@"Ion creates a theme with image")]
        [When(@"Ion creates a theme with image")]
        public async Task GivenIonCreatesAThemeWithImage()
        {
            FileBlob imageFile = new()
            {
                Id = "FileBlob_1",
                Content = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAAgAAAAIAQMAAAD+wSzIAAAABlBMVEX///+/v7+jQ3Y5AAAADklEQVQI12P4AIX8EAgALgAD/aNpbtEAAAAASUVORK5CYII="),
                Mimetype = "image/png",
                Description = "tiny_image.png",
                CreatedAt = DateTime.Now.ToUniversalTime()
            };
            string uploadJson = await ((TeacherWorkoutApiClient)_scenarioContext["Ion"]).UploadImage(imageFile);
            string fileBlobId = JObject.Parse(uploadJson)["data"]["singleUpload"]["fileBlobId"].ToString();

            _scenarioContext["theme-create-response"] = await ((TeacherWorkoutApiClient) _scenarioContext["Ion"]).ThemeCreateAsync(fileBlobId);
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