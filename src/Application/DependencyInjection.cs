using Domain.Common.Interfaces.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Application.Common.Behaviors;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(IRepository<,>).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(RequestValidationBehavior<,>));
           // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));

            

            return services;
        }
    }
}
