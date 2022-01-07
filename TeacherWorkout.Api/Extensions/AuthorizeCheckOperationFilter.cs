﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TeacherWorkout.Api.Extensions
{
    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context?.MethodInfo?.DeclaringType == null)
            {
                return;
            }

            var attributes = context.MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .ToList();

            if (attributes.OfType<IAllowAnonymous>().Any())
            {
                return;
            }

            var authAttributes = attributes
                .OfType<IAuthorizeData>()
                .ToList();

            if (authAttributes.Any())
            {
                operation.Responses["401"] = new OpenApiResponse { Description = "Unauthorized" };

                if (authAttributes.Any(att => !String.IsNullOrWhiteSpace(att.Roles) || !String.IsNullOrWhiteSpace(att.Policy)))
                {
                    operation.Responses["403"] = new OpenApiResponse { Description = "Forbidden" };
                }

                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new ()
                    {
                        {
                            new()
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            Array.Empty<string>()
                        }
                    }
                };
            }
        }

    }
}