using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TeacherWorkout.Common.Authorization;
using TeacherWorkout.Common.Extensions;
using TeacherWorkout.Identity.Options;

namespace TeacherWorkout.Identity
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBearerAuth(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.Configure<JwtConfig>(configuration.GetSection(JwtConfig.SectionName));
            services.Configure<PasswordOptions>(configuration.GetSection(nameof(PasswordOptions)));

            var jwtConfig = services.GetOptions<JwtConfig>(JwtConfig.SectionName);
            var passwordOptions = services.GetOptions<PasswordOptions>(nameof(PasswordOptions));

            var key = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = false,
                ClockSkew = TimeSpan.Zero,
                RoleClaimType = AuthorizationRoles.ClaimName
            };

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwt =>
                {
                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = tokenValidationParams;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthorizationPolicies.AdminOnly, policy => policy.RequireRole(AuthorizationRoles.Admin));
            });

            services.Configure<IdentityOptions>(options => { options.Password = passwordOptions; });

            services.AddDbContext<UserContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("IdentityDbConnectionString")));

            services
                .AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<UserContext>();
        }
    }
}
