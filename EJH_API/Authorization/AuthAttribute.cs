using DataBase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        List<Guid> _roles = new List<Guid>();
        public AuthorizeAttribute(params string[] roles)
        {
            foreach (var role in roles)
            {
                _roles.Add(Guid.Parse(role));
            }
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            User user = (User)context.HttpContext.Items["User"];
            Guid[] roles = (Guid[])context.HttpContext.Items["Roles"];

            if (user == null)
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };

            if (roles != null)
                if (_roles.Intersect(roles) != null)
                    context.Result = new JsonResult(new { message = "Permission deried" }) { StatusCode = StatusCodes.Status403Forbidden };

        }
        public void OnAuthorization(AuthorizationFilterContext context, string aaa)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            User user = (User)context.HttpContext.Items["User"];
            if (user == null)
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
