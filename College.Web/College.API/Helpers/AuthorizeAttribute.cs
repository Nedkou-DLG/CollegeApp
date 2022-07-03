using System;
using College.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace College.API.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<UserType> _roles;
        public AuthorizeAttribute(params UserType[] roles)
        {
            _roles = roles ?? new UserType[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (UserRecord)context.HttpContext.Items["User"];
            if (user == null || (_roles.Any() && !_roles.Contains(user.UserType)))
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}

