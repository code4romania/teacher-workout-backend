using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Domain.Lessons;
using TeacherWorkout.Domain.Models;
using TeacherWorkout.MockData.Repositories;
using Xunit;

namespace TeacherWorkout.Api.Tests.Query
{
    public class LessonsTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly GraphQLHttpClient _graphQLClient;

        public LessonsTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _graphQLClient = CreateClient();
        }
        
        [Fact]
        public async Task Lessons_WithNoArguments_ReturnsDefaultResponse()
        {
            var response = await _graphQLClient.SendQueryAsync(@"query Lessons {
  lessons {
    items {
      id
      title
    }
  }
}", new {}, 
                "Lessons",
                () => new { lessons = new PaginatedResult<Lesson>() });

            response.Errors.Should().BeNull();
            response.Data.Should().NotBeNull();
        }
        
        private GraphQLHttpClient CreateClient()
        {

            var factory = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.Replace(ServiceDescriptor.Singleton<ILessonRepository, LessonRepository>());
                });
            });
            var httpClient = factory.CreateClient();
            
            return new GraphQLHttpClient(
                new GraphQLHttpClientOptions { EndPoint = new Uri("http://localhost/graphql") }, 
                new SystemTextJsonSerializer(), 
                httpClient);
        }
    }
}