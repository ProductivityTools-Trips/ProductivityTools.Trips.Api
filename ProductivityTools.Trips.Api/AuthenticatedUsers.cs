﻿using System.Security.Claims;

namespace ProductivityTools.Trips.Api
{
    public class AuthenticatedUsersAttribute : Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    {
        public AuthenticatedUsersAttribute()
        {
        }
        public override void OnActionExecuting(Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext context)
        {
            var x1 = context.HttpContext.User;
            var identity = (ClaimsIdentity)x1.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var email = claims.First(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;

            if (email == "pwujczyk@gmail.com")
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
            }
        }
    }
}
 