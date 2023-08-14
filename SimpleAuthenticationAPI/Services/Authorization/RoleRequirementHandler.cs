using Microsoft.AspNetCore.Authorization;
using SimpleAuthenticationAPI.Models;
using System.Security.Claims;

namespace SimpleAuthenticationAPI.Services.Authorization
{
    /// <summary>
    /// A custom requirement handler
    /// </summary>
    public class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
    {
        /// <summary>
        /// Check if the user is authroized 
        /// and also check if the user has access to the endpoint
        /// </summary>
        /// <param name="context">Contains authorization information</param>
        /// <param name="requirement">An instance of a custom requirement/>
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            var user = context.User;
            if (!user.Identity.IsAuthenticated)
            {
                context.Fail();
                return;
            }

            var resource = context.Resource as DefaultHttpContext;
            var endpoint = resource.GetEndpoint();
            var attribute = endpoint.Metadata.GetMetadata<HasRoleAttribute>();
            var userRole = context.User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Role).Value;

            Enum.TryParse(typeof(Role), userRole, out object currentRole);
            if (currentRole == null)
            {
                context.Fail();
                return;
            }

            if (!attribute.Roles.Contains((Role)currentRole))
            {
                context.Fail();
            }
            context.Succeed(requirement);
        }
    }
}
