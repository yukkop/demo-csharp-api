using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Authorization;

public class HandledAuthorizeAttribute: Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (!user.Identity.IsAuthenticated)
        {
            // Add your logic here to check variables, log unauthorized access, etc.
            // For example:
            var controller = (string)context.RouteData.Values["controller"];
            var action = (string)context.RouteData.Values["action"];

            // Log the unauthorized access
            Debug.WriteLine($"Unauthorized request: Controller={controller}, Action={action}");

            // Handle the unauthorized request
            context.Result = new UnauthorizedResult();
        }
    }
}