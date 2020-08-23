using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace primenumberapi.Filters
{
    public class SecurityFilter
        : Attribute, 
        IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            // If the env token is not set, no one gets in
            if (Environment.GetEnvironmentVariable("AUTH_STATIC_TOKEN").Trim().Length == 0)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                return;
            }

            if (!context.HttpContext.Request.Headers.ContainsKey("AuthToken"))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                return;
            }

            string token = context.HttpContext.Request.Headers["AuthToken"];

            if (string.Compare(token, Environment.GetEnvironmentVariable("AUTH_STATIC_TOKEN"), false) != 0)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                return;
            }

        }

    }

}
