
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Vizitz.Entities;

namespace Vizitz.Services.Requirements
{
    public class VerifiedProprietorHandler : AuthorizationHandler<VerifiedProprietorRequirement>
    {
        private readonly IAuthManager _authManager;

        public VerifiedProprietorHandler(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, VerifiedProprietorRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                return Task.CompletedTask;
            }

            string userName = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            User user = _authManager.GetUserDetail(userName).Result;

            if (user != null && user.EmailConfirmed)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
