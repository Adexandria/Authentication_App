using Microsoft.AspNetCore.Authorization;
using SimpleAuthenticationAPI.Models;

namespace SimpleAuthenticationAPI.Services.Authorization
{
    public class HasRoleAttribute : AuthorizeAttribute
    {
        public HasRoleAttribute(params Role[] roles) : base(Policy)
        {
            Roles = roles;
        }
        public Role[] Roles { get; set; }
        internal const string Policy = "HasRoleType";
    }
}
