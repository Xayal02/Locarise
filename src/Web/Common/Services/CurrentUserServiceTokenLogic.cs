using Application.Common.Authorization;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Linq;

namespace Web.Common.Services
{
    public class CurrentUserServiceTokenLogic : ICurrentUserService
    {
        public long? UserId { get; set; }

        public CurrentUserServiceTokenLogic(IHttpContextAccessor httpContextAccessor)
        {
            if(httpContextAccessor.HttpContext != null )
            {
               var userClaims = TokenFactory.ReturnCurrentUserClaims(httpContextAccessor.HttpContext);

                UserId =  Convert.ToInt64(userClaims["Id"]);
            }
        }
    }
}
