﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeacherWorkout.Identity.Services;

namespace TeacherWorkout.Identity.Api
{
    public static class BootstrappingExtensions
    {
        public static void AddIdentityApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBearerAuth(configuration);

            services.AddTransient<IJwtService, JwtService>();
        }
    }
}
