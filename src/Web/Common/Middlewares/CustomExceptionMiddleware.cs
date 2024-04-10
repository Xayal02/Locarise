using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Exceptions;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using FluentValidation;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using Stripe;

namespace Web.Common.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(ex, context);
            }
        }

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    var originalBody = context.Response.Body;

        //    try
        //    {
        //        // Buffer the response so that we can read it
        //        using (var responseBody = new MemoryStream())
        //        {
        //            context.Response.Body = responseBody;

        //            await _next(context);
        //            var errorsDictionary = new Dictionary<string, List<string>>();


        //            if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
        //            {

        //                responseBody.Seek(0, SeekOrigin.Begin);

        //                using (var streamReader = new StreamReader(responseBody, Encoding.UTF8, true, 1024, true))
        //                {
        //                    var responseBodyString = await streamReader.ReadToEndAsync();

        //                    var responseObject = JObject.Parse(responseBodyString);

        //                    var errors = responseObject["errors"];

        //                    foreach (var error in errors)
        //                    {
        //                        var propertyName = ((JProperty)error).Name;

        //                        var errorMessages = error.First.ToObject<List<string>>();

        //                        errorsDictionary.Add(propertyName, errorMessages);
        //                    }
        //                }

        //            }
        //            context.Response.Body = originalBody;

        //            throw new Domain.Exceptions.ValidationException(errorsDictionary);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        context.Response.Body = originalBody;
        //        await HandleExceptionAsync(ex, context);
        //    }
        //}

        private async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;

            switch (exception)
            {
                case AlreadyExistException alreadyExistException:
                    code = HttpStatusCode.BadRequest;
                    break;

                case NotFoundException notFoundException:
                   code = HttpStatusCode.NotFound;
                   break;

                case ApiException apiException:
                    code = HttpStatusCode.BadRequest;
                    break;

                case BadRequestException apiException:
                    code = HttpStatusCode.BadRequest;
                    break;

                case SecurityTokenException securityTokenException:
                    code = HttpStatusCode.Forbidden;
                    break;

                case UnauthorizedException unauthorizedException:
                    code = HttpStatusCode.Unauthorized;
                    break;

                case Domain.Exceptions.ValidationException validationException:
                    code = HttpStatusCode.NotAcceptable;
                    result = JsonConvert.SerializeObject(validationException.Errors);
                    break;

                //case StripeError stripeError:
                //    result = JsonConvert.SerializeObject("An error has occurred while performing payment...");
                //    break;

                default:
                    code = HttpStatusCode.InternalServerError;
                    result = JsonConvert.SerializeObject("An unexpected error has occurred");
                    break;

            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (string.IsNullOrEmpty(result))
            {
                result = JsonConvert.SerializeObject(new { error = exception.Message });
            }

            await context.Response.WriteAsync(result);
        }


    }

}
