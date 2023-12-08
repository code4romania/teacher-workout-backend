using System;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TeacherWorkout.Domain.Models;
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
            ThemeCreate,
            SingleUpload
        }
        
        private readonly HttpClient _client;

        public TeacherWorkoutApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> UploadImage(FileBlob imageFile)
        {

            var operations = new StringContent(new {query = GraphQL("Mutation", "SingleUpload"), variables = new {file = (string)null}}.ToJson(), Encoding.UTF8, "application/json");
            var map = new StringContent("{\"0\": [\"variables.file\"]}", Encoding.UTF8, "application/json");
            var imageBytes = new ByteArrayContent(imageFile.Content);
            imageBytes.Headers.Add("Content-Type", imageFile.Mimetype);

            var multipartContent = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture))
            {
                { operations, "operations" },
                { map, "map" },
                { imageBytes, "0", imageFile.Description }
            };
            var response = await _client.PostAsync("http://localhost/graphql", multipartContent);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> ThemesAsync()
        {
            return await SendRequest(QueryFor(Queries.Themes), new {});
        }

        public async Task<string> ThemeCreateAsync(string fileBlobId)
        {
            return await SendRequest(MutationFor(Mutations.ThemeCreate), new
            {
                input = new
                {
                    title = "foo",
                    fileBlobId,
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
    }
}
