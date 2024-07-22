using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infastructure;
using Application.Common.Interfaces;
using Web.Common.Services;
using Application;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Web.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Hellang.Middleware.ProblemDetails;
using Stripe;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.UseSwagger(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddApplicationLayer();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(Application.CQRS.Commands.UserCommands.Add.AddUserCommand).Assembly);

//builder.Services.UseCustomizedProblemDetails();




//builder.Services.AddAuthentication()
//                .AddGoogle(googleOptions =>
//                {
//                    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
//                    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
//                });


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});


builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ICurrentUserService, CurrentUserServiceTokenLogic>();

builder.Services.ConfigureStripePayment(builder.Configuration);


var app = builder.Build();

app.UseRouting();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // change the location Khayal


//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCustomExceptionMiddleware();

app.UseStaticFiles();

//app.UseProblemDetails();


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();