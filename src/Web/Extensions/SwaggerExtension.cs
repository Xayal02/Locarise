using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using static System.Net.WebRequestMethods;

namespace Web.Extensions
{
    public  static class SwaggerExtension
    {
        public static IServiceCollection UseSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Locarise BackEnd Services",
                    Contact = new OpenApiContact()
                    {
                        Name = "Locarise Contact",
                        Url = new Uri(configuration.GetSection("Contact")["Url"])
                    }
                });

                options.AddSecurityDefinition("JWTBearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Add JWT Token Here",
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = "JWTBearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });


            });

            return services;
        }
    }
}
