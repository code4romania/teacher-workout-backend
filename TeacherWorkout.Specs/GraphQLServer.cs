using System;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.Mvc.Testing;
using TeacherWorkout.Api;

namespace TeacherWorkout.Specs
{
    public class GraphQLServer
    {       
        private readonly WebApplicationFactory<Startup> _factory;

        public GraphQLHttpClient Client =>
            new(
                new GraphQLHttpClientOptions { EndPoint = new Uri("http://localhost/graphql") }, 
                new SystemTextJsonSerializer(), 
                _factory.CreateClient());

        public GraphQLServer(WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                });
            });
        }
    }
}