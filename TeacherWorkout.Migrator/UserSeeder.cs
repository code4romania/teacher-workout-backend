using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TeacherWorkout.Common.Authorization;
using TeacherWorkout.Data;
using TeacherWorkout.Domain.Models;

namespace TeacherWorkout.Migrator
{
    internal class UserSeeder
    {
        private readonly TeacherWorkoutContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserSeeder(TeacherWorkoutContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedDefaultAdmin(string adminEmail, string password)
        {
            var adminAlreadyExits = await _userManager.FindByEmailAsync(adminEmail);
            if (adminAlreadyExits is not null)
            {
                Console.WriteLine($"Admin account with email {adminEmail} already exists.");
                return;
            }

            var admin = new IdentityUser
            {
                Email = adminEmail,
                UserName = adminEmail
            };

            var adminCreated = await _userManager.CreateAsync(admin, password);
            if (adminCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(admin, AuthorizationRoles.Admin);

                var user = new User
                {
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "Admin"
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                Console.WriteLine($"Added admin account with email {adminEmail}.");
            }
            else
            {
                Console.WriteLine("Error creating admin account:");
                var errors = new StringBuilder();
                errors.AppendJoin(',', adminCreated.Errors.Select(e => e.Description));
                Console.WriteLine(errors.ToString());
            }
        }
    }
}