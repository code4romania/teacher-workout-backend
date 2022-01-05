﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

            services.Configure<IdentityOptions>(options => { options.Password = passwordOptions; });

            services.AddDatabase<UserContext>(configuration.GetConnectionString("IdentityDbConnectionString"));

            services
                .AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<UserContext>();
        }

        public static IServiceCollection AddDatabase<T>(this IServiceCollection services, string connectionString) where T : DbContext
        {
            services.AddDbContextPool<T>(options =>
                options.UseNpgsql(connectionString, sqlOptions => sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorCodesToAdd: null
                )));

            return services;
        }
        
        public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var section = configuration.GetSection(sectionName);
            var options = new T();
            section.Bind(options);

            return options;
        }
    }
}
