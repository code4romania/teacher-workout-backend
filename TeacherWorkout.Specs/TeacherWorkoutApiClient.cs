using System.IO;
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
        enum Queries
        {
            Themes
        }

        enum Mutations
        {
            ThemeCreate
        }
        
        private readonly GraphQLHttpClient _client;

        public TeacherWorkoutApiClient(GraphQLHttpClient client)
        {
            _client = client;
        }

        public async Task<Result<PaginatedResult<Theme>>> ThemesAsync()
        {
            var response = await _client.SendQueryAsync(QueryFor(Queries.Themes),
                new { },
                Queries.Themes.ToString(),
                () => new {themes = new PaginatedResult<Theme>()});

            return new Result<PaginatedResult<Theme>>
            {
                Data = response.Data.themes,
                Errors =  response.Errors
            };
        }

        public async Task<Result<ThemeCreatePayload>> ThemeCreateAsync()
        {
            var response = await _client.SendQueryAsync(MutationFor(Mutations.ThemeCreate),
                new
                {
                    input = new ThemeCreateInput
                    {
                        Title = "foo"
                    }
                },
                Mutations.ThemeCreate.ToString(),
                () => new {themeCreate = new ThemeCreatePayload()});

            return new Result<ThemeCreatePayload>
            {
                Data = response.Data.themeCreate,
                Errors =  response.Errors
            };
        }

        private string QueryFor(Queries query)
        {
            return GraphQL("Query", query.ToString());
        }


        private string MutationFor(Mutations mutation)
        {
            return GraphQL("Mutation", mutation.ToString());
        }

        private string GraphQL(string category, string name)
        {
            return File.ReadAllText($"GraphQL/{category}/{name}.graphql");
        }
    }
}
