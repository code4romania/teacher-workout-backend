using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TeacherWorkout.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerFor(this IServiceCollection services, Assembly[] assemblies, IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme.ToLowerInvariant(),
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Description = "JWT Authorization header using the Bearer scheme."
                };
                c.AddSecurityDefinition("Bearer", jwtSecurityScheme);
                c.OperationFilter<AuthorizeCheckOperationFilter>();

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TeacherWorkout API",
                    Description = "The authorization part or the TeacherWorkout backend application.",
                    TermsOfService = new Uri("https://github.com/code4romania/teacher-workout-backend"),
                    Contact = new OpenApiContact
                    {
                        Name = "Code4Romania",
                        Email = string.Empty,
                        Url = new Uri("https://code4.ro/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under Mozilla Public License Version 2.0",
                        Url = new Uri("https://github.com/code4romania/teacher-workout-backend/blob/develop/LICENSE"),
                    }
                });

                foreach (var assembly in assemblies)
                {
                    var xmlFile = $"{assembly.GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                }

            });

            return services;
        }
    }
}
