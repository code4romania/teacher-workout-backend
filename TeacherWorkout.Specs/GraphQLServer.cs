using System.Linq;
using System.Net.Http;
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

        public HttpClient Client => _factory.CreateClient();

        public WebApplicationFactory<Startup> Factory => _factory;

        public GraphQLServer(WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var existingContext = services.First(x =>
                        x.ServiceType == typeof(TeacherWorkoutContext)
                        && x.Lifetime == ServiceLifetime.Scoped);
                    services.Remove(existingContext);

                    services.AddSingleton(p =>
                    {
                        var configuration = p.GetService<IConfiguration>();
                        var options = new DbContextOptionsBuilder<TeacherWorkoutContext>()
                            .UseNpgsql(configuration.GetConnectionString("TeacherWorkoutContext"))
                            .Options;
                        return new TeacherWorkoutContext(options);
                    });
                });
            });
            _factory.Server.PreserveExecutionContext = true;
        }
    }
}