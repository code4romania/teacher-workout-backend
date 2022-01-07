using System;
using System.Linq;
using System.Reflection;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.SwaggerUI;
using TeacherWorkout.Api.Extensions;
using TeacherWorkout.Api.GraphQL;
using TeacherWorkout.Api.GraphQL.ValidationRules;
using TeacherWorkout.Data;
using TeacherWorkout.Domain.Common;
using TeacherWorkout.Identity.Api;
using TeacherWorkout.Identity.Api.Controllers;

namespace TeacherWorkout.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            services.AddScoped<TeacherWorkoutQuery>();
            services.AddScoped<TeacherWorkoutMutation>();
            services.AddScoped<ISchema, TeacherWorkoutSchema>();
            AddOperations(services);
            AddRepositories(services, "TeacherWorkout.Data");
            AddValidationRules(services);

            services.AddHttpContextAccessor();
            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = false;
                })
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddSystemTextJson()
                .AddGraphTypes()
                .AddUserContextBuilder(httpContext => new GraphQlUserContext(httpContext.User));
            
            services.AddControllers();

            var applicationAssemblies = GetAssemblies();
            services.AddSwaggerFor(applicationAssemblies, Configuration);

            services.AddDbContext<TeacherWorkoutContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("TeacherWorkoutContext")));

            services.AddIdentityApiServices(Configuration);
        }

        private static void AddValidationRules(IServiceCollection services)
        {
            services.AddScoped<IValidationRule, RequiresAuthValidationRule>();
        }

        private Assembly[] GetAssemblies() => new[] { typeof(AuthController).GetTypeInfo().Assembly };

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TeacherWorkoutContext db)
        {
            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQLPlayground();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.ConfigObject = new ConfigObject
                {
                    Urls = new[]
                    {
                        new UrlDescriptor{Name = "api", Url = "/swagger/v1/swagger.json"}
                    }
                };
            });
        }

        private static void AddOperations(IServiceCollection services)
        {
            var operationType = typeof(IOperation);
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsClass)
                .Where(t => t.GetInterfaces().Contains(operationType))
                .ToList()
                .ForEach(t => services.AddScoped(t));
        }

        private static void AddRepositories(IServiceCollection services, string sourceNamespace)
        {
            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass)
                .Where(t => t.Namespace != null && t.Namespace.StartsWith(sourceNamespace))
                .Where(t => t.Name.EndsWith("Repository"))
                .ToList()
                .ForEach(t =>
                {
                    var repositoryInterface = t.GetInterfaces().First(i => i.Name.EndsWith("Repository"));
                    services.AddScoped(repositoryInterface, t);
                });
        }
    }
}
