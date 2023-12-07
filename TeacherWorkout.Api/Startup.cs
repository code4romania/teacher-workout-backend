using System;
using System.Linq;
using GraphQL;
using GraphQL.Types;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TeacherWorkout.Api.GraphQL;
using TeacherWorkout.Api.Jobs;
using TeacherWorkout.Api.Jobs.Config;
using TeacherWorkout.Api.Jobs.Interfaces;
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

            services.AddControllers();
            services.AddHttpContextAccessor();
            services
                .AddGraphQLUpload()
                .AddGraphQL(b => b
                    .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true)
                    .AddGraphTypes()
                    .AddSystemTextJson());

            services.AddDbContext<TeacherWorkoutContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("TeacherWorkoutContext")));
            
            services.AddHangfire(configuration =>
            {
                configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
                configuration.UseSimpleAssemblyNameTypeSerializer();
                configuration.UseRecommendedSerializerSettings();

                // Initialize JobStorage
                configuration.UsePostgreSqlStorage(c =>
                    c.UseNpgsqlConnection(Configuration.GetConnectionString("TeacherWorkoutContext")));
            });
            services.AddHangfireServer(config => config.WorkerCount = 1);

            services.Configure<DeleteOldFileBlobsConfig>(Configuration.GetSection("TeacherWorkout:RecurringJobs:DeleteOldFileBlobs"));
            services.AddScoped<IDeleteOldFileBlobsJob, DeleteOldFileBlobsJob>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TeacherWorkoutContext db, IServiceProvider serviceProvider)
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
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.UseGraphQLUpload<ISchema>()
                .UseGraphQL<ISchema>();
            app.UseGraphQLGraphiQL();

            var deleteOldFileBlobsConfig = Configuration.GetSection("TeacherWorkout:RecurringJobs:DeleteOldFileBlobs")
                .Get<DeleteOldFileBlobsConfig>();
            if (deleteOldFileBlobsConfig.IsEnabled)
            {
                RecurringJob.AddOrUpdate<IDeleteOldFileBlobsJob>(
                    nameof(DeleteOldFileBlobsJob),
                    job => job.Run(),
                    deleteOldFileBlobsConfig.CronExpression,
                    new RecurringJobOptions { TimeZone = TimeZoneInfo.Utc }
                );
            }
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
