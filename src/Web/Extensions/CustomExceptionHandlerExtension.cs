using Microsoft.AspNetCore.Builder;
using Web.Common.Middlewares;

namespace Web.Extensions
{
    public static class CustomExceptionHandlerExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseMiddleware<CustomExceptionMiddleware>();

            return appBuilder;
        }
    }
}
