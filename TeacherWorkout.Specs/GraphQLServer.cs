using System;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeacherWorkout.Api;
using TeacherWorkout.Data;

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

        public WebApplicationFactory<Startup> Factory => _factory;

        private string EnvName => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        public GraphQLServer(WebApplicationFactory<Startup> factory)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{EnvName}.json")
                .Build();
            
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var options = new DbContextOptionsBuilder<TeacherWorkoutContext>()
                        .UseNpgsql(config.GetConnectionString("TeacherWorkoutContext"))
                        .Options;
                    services.AddSingleton(_ => new TeacherWorkoutContext(options));
                });
            });
            _factory.Server.PreserveExecutionContext = true;
        }
    }
}