using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;
using Web.Common.Services;

namespace Web.Extensions
{
    public static class StripeExtension
    {
        public static IServiceCollection ConfigureStripePayment(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<TokenService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<ChargeService>();

            StripeConfiguration.ApiKey = configuration.GetSection("StripeOptions")["SecretKey"];

            services.AddScoped<IStripeService, StripeService>();

            return services;
        }
    }
}
