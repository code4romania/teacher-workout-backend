using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeacherWorkout.Common.Authorization;

namespace TeacherWorkout.Identity
{
    public class UserContext : IdentityDbContext
    {
        public UserContext(DbContextOptions<UserContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("identity");

            modelBuilder
                .Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Id = "c1f498cb-4d43-4961-8d3e-d0fd96481f1a",
                    Name = AuthorizationRoles.Admin,
                    NormalizedName = AuthorizationRoles.Admin.ToUpper()
                });

            modelBuilder
                .Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
                    Id = "b654f143-d497-47d0-b417-ff520f9adbfe",
                    Name = AuthorizationRoles.User,
                    NormalizedName = AuthorizationRoles.User.ToUpper()
                });
        }
    }
}
