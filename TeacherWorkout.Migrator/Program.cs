using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeacherWorkout.Data;

namespace TeacherWorkout.Migrator
{
    class Program
    {
        private static object DefaultEnvironmentName => "Development";
        private static string EnvironmentName => (string) (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? DefaultEnvironmentName);


        static async Task Main(string[] args)
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().Location);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var services = new ServiceCollection();

            Console.WriteLine("Database Migrator");
            Console.WriteLine("Registering contexts.");
            services.AddDbContext<TeacherWorkoutContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("TeacherWorkoutContext")));
            Console.WriteLine("Done: Registering contexts.");

            Console.WriteLine("Getting contexts");
            var serviceProvider = services.BuildServiceProvider();
            var teacherWorkoutContext = serviceProvider.GetService<TeacherWorkoutContext>();
            var dbContexts = new DbContext[]
            {
                teacherWorkoutContext
            };
            Console.WriteLine("Done: Getting contexts");

            await ApplyMigrations(dbContexts);

            await SeedData(configuration, teacherWorkoutContext);
        }

        private static async Task ApplyMigrations(DbContext[] dbContexts)
        {
            Console.WriteLine("Applying migrations");

            foreach (var dbContext in dbContexts)
            {
                Console.WriteLine($"Migrating {dbContext.GetType().Name}.");
                await dbContext.CreateAndMigrateAsync();
                Console.WriteLine($"Done: Migrating {dbContext.GetType().Name}.");
                
            }

            Console.WriteLine("Database migration finished.");
            Console.WriteLine("--------------------------------------------");
        }

        private static async Task SeedData(IConfigurationRoot configuration, TeacherWorkoutContext? teacherWorkoutContext)
        {
            var seedDataEnabled = bool.Parse(configuration["SeedData"]);
            if (!seedDataEnabled)
            {
                return;
            }

            Console.WriteLine("Starting database seed.");
            await new TeacherWorkoutSeeder(teacherWorkoutContext).Seed();

            Console.WriteLine("Finished seeding database.");
            Console.WriteLine("--------------------------------------------");
        }
    }
}
