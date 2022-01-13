using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TeacherWorkout.Specs.Extensions;

namespace TeacherWorkout.Specs
{
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
        
        private readonly HttpClient _client;

        public TeacherWorkoutApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> ThemesAsync()
        {
            return await SendRequest(QueryFor(Queries.Themes), new {});
        }

        public async Task<string> ThemeCreateAsync()
        {
            return await SendRequest(MutationFor(Mutations.ThemeCreate), new
            {
                input = new
                {
                    title = "foo"
                }
            });
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

        private async Task<string> SendRequest(string query, object variables)
        {
            var content = new StringContent(new {query, variables}.ToJson(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost/graphql", content);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<bool> Register(string name)
        {
            var registerJsonRequest = $"{{ \"email\" : \"{name}@example.com\", \"password\":\"password\" }}";

            var content = new StringContent(registerJsonRequest, Encoding.UTF8, "application/json");
            var result = await _client.PostAsync("http://localhost/auth/register", content);
            
            return result.IsSuccessStatusCode;
        }

        public async Task Login(string name)
        {
            var registerJsonRequest = $"{{ \"email\" : \"{name}@example.com\", \"password\":\"password\" }}";

            var content = new StringContent(registerJsonRequest, Encoding.UTF8, "application/json");
            var result = await _client.PostAsync("http://localhost/auth/login", content);

            var loginResponse = await result.Content.ReadFromJsonAsync<LoginResponse>();

            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {loginResponse.Token}");
        }
    }
}
