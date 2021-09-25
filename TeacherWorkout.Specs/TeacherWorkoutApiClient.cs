using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.Domain.Models.Inputs;
using TeacherWorkout.Domain.Models.Payloads;

namespace TeacherWorkout.Specs
{
    public class Result<TWrappedResult>
    {
        public TWrappedResult Data { get; set; }
        public GraphQLError[] Errors { get; set; }
    }
    public class TeacherWorkoutApiClient
    {
        private readonly GraphQLHttpClient _client;

        public TeacherWorkoutApiClient(GraphQLHttpClient client)
        {
            _client = client;
        }

        public async Task<Result<PaginatedResult<Theme>>> ThemesAsync()
        {
            var response = await _client.SendQueryAsync(@"query Themes {
  themes {
    items {
      id
      title
    }
  }
}", new { },
                "Themes",
                () => new {themes = new PaginatedResult<Theme>()});

            return new Result<PaginatedResult<Theme>>
            {
                Data = response.Data.themes,
                Errors =  response.Errors
            };
        }

        public async Task<Result<ThemeCreatePayload>> ThemeCreateAsync()
        {
            var response = await _client.SendQueryAsync(@"mutation ThemeCreate($input: ThemeCreateInput!) {
  themeCreate(input: $input) {
    theme {
      id
      title
    }
  }
}", new
                {
                    input = new ThemeCreateInput
                    {
                        Title = "foo"
                    }
                },
                "ThemeCreate",
                () => new { themeCreate = new ThemeCreatePayload() });

            return new Result<ThemeCreatePayload>
            {
                Data = response.Data.themeCreate,
                Errors =  response.Errors
            };
        }
    }
}
