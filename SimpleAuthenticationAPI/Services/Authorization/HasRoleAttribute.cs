using Microsoft.AspNetCore.Authorization;
using SimpleAuthenticationAPI.Models;

namespace SimpleAuthenticationAPI.Services.Authorization
{
    /// <summary>
    /// A custom authorize attribute to allow certain roles to have access to methods or classes
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class HasRoleAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// A constructor that specifies the policy name
        /// </summary>
        /// <param name="roles">A list of roles</param>
        public HasRoleAttribute(params Role[] roles) : base(Policy)
        {
            Roles = roles;
        }

        /// <summary>
        /// Roles accepted
        /// </summary>
        public Role[] Roles { get; set; }

        /// <summary>
        /// Policy name
        /// </summary>
        public const string Policy = "HasRoleType";
    }
}
