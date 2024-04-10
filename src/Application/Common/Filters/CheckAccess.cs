using Application.Common.Authorization;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Filters
{
    public class CheckAccess : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(SkipAuthorization(context)) return;

            if (string.IsNullOrEmpty(context.HttpContext.Request.Headers["Authorization"]))
            {
                throw new UnauthorizedException();
            }
            else
            {
                var token = context.HttpContext.Request.Headers["Authorization"];

                var claims = TokenFactory.TokenReader(token);
                int id =  Convert.ToInt32(claims["Id"]);
                if (id == 0) throw new UnauthorizedException();
            }
        }
        private bool SkipAuthorization(ActionExecutingContext context)
        {
            var controllerDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            return controllerDescriptor.MethodInfo.GetCustomAttributes(inherit: true).Any(a => a.GetType().Equals(typeof(AllowAnonymousAttribute)));
        }
    }
}
