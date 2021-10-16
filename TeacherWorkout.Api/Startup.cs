using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TeacherWorkout.Api.GraphQL;
using TeacherWorkout.Data;
using TeacherWorkout.Domain.Common;

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
            EnsureReferencedAssembliesAreLoaded();
            
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
            AddRepositories(services, "TeacherWorkout.MockData");
            AddRepositories(services, "TeacherWorkout.Data");

            services.AddHttpContextAccessor();
            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = false;
                })
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddSystemTextJson()
                .AddGraphTypes();

            services.AddDbContext<TeacherWorkoutContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("TeacherWorkoutContext")));
        }

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

            db.Database.Migrate();

            app.UseRouting();

            app.UseGraphQL<ISchema>();
            app.UseGraphQLGraphiQL();
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
        
        private static void EnsureReferencedAssembliesAreLoaded()
        {
            // We need to reference something in the assembly to make it load  
            // otherwise the Compiler will not include it in the output package
            new List<Assembly> { typeof(MockData.Repositories.StepRepository).Assembly };
        }
    }
}
