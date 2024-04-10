﻿
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text.RegularExpressions;

namespace Web.Common.Services
{
    public class CurrentUserService : ICurrentUserService
    { 

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {

            if (long.TryParse(GetHeaderValue(httpContextAccessor,"Id"),out long userId))
            {
                UserId = userId;
            }
        }
        public long? UserId { get; set;}

        private string GetHeaderValue(IHttpContextAccessor httpContextAccessor,string headerKey)
        {
            if (httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.Request.Headers.TryGetValue(headerKey, out StringValues stringValue))
            {
                return stringValue.First();
            }

            return string.Empty;
        }
    }
}