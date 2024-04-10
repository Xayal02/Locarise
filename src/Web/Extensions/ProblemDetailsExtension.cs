using Hellang.Middleware.ProblemDetails;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Diagnostics;
using Domain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;


namespace Web.Extensions
{
    public static class ProblemDetailsExtension
    {
        //public static IServiceCollection UseCustomizedProblemDetails(this IServiceCollection services)
        //{
        //    services.AddProblemDetails(options =>
        //    {
        //        options.IncludeExceptionDetails = (ctx, env) => false;


        //        options.MapStatusCode = (context) =>
        //        {
        //            IExceptionHandlerFeature? exceptionContext = context.Features.Get<IExceptionHandlerFeature>();
        //            var statusCode = context.Response.StatusCode;
        //            string detail = string.Empty;
        //            string title = "Something went wrong !";

        //            if (exceptionContext != null && exceptionContext.Error != null)
        //            {
        //                switch (exceptionContext.Error)
        //                {
        //                    case AlreadyExistException ex:
        //                        statusCode = StatusCodes.Status400BadRequest;
        //                        detail = ex.Message;
        //                        break;
        //                    case NotFoundException ex:
        //                        statusCode = StatusCodes.Status404NotFound;
        //                        detail = ex.Message;
        //                        break;
        //                    case Domain.Exceptions.ValidationException ex:
        //                        statusCode = StatusCodes.Status406NotAcceptable;
        //                        detail = JsonConvert.SerializeObject(ex.Errors);
        //                        break;

        //                    default:
        //                        statusCode = 400;
        //                        break;
        //                }
        //            }
        //            return new ProblemDetails()
        //            {
        //                Title = title,
        //                Detail = detail,
        //                Status = statusCode
        //            };
        //        };
        //    });

        //    return services;
        //}
    }
}
