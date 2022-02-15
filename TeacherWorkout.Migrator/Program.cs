using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeacherWorkout.Common.Extensions;
using TeacherWorkout.Data;
using TeacherWorkout.Identity;

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

            services.AddDbContext<UserContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("IdentityDbConnectionString")));
            Console.WriteLine("Done: Registering contexts.");

            services
                .AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<UserContext>();
            ConfigurePasswordOptions(services, configuration);

            Console.WriteLine("Getting contexts");
            var serviceProvider = services.BuildServiceProvider();

            var teacherWorkoutContext = serviceProvider.GetService<TeacherWorkoutContext>();
            var userContext = serviceProvider.GetService<UserContext>();

            var dbContexts = new DbContext[]
            {
                teacherWorkoutContext,
                userContext
            };
            Console.WriteLine("Done: Getting contexts");

            await ApplyMigrations(dbContexts);

            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            await SeedData(configuration, teacherWorkoutContext);
            await SeedUsers(configuration, teacherWorkoutContext, userManager);
        }

        private static void ConfigurePasswordOptions(ServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.Configure<PasswordOptions>(configuration.GetSection(nameof(PasswordOptions)));
            var passwordOptions = services.GetOptions<PasswordOptions>(nameof(PasswordOptions));
            services.Configure<IdentityOptions>(options => { options.Password = passwordOptions; });
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

        private static async Task SeedData(IConfigurationRoot configuration, TeacherWorkoutContext teacherWorkoutContext)
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

        private static async Task SeedUsers(IConfigurationRoot configuration,
            TeacherWorkoutContext teacherWorkoutContext, UserManager<IdentityUser> userManager)
        {
            var seedUsersEnabled = bool.Parse(configuration["SeedUsers"]);
            if (!seedUsersEnabled)
            {
                return;
            }

            Console.WriteLine("Starting users seed.");
            var adminEmail = configuration["Admin:EmailAddress"];
            var adminPassword = configuration["Admin:Password"];
            await new UserSeeder(teacherWorkoutContext, userManager).SeedDefaultAdmin(adminEmail, adminPassword);

            Console.WriteLine("Finished seeding users.");
            Console.WriteLine("--------------------------------------------");
        }
    }
}
