using System.Security.Claims;

namespace Reputy.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId == null ? throw new UnauthorizedAccessException("Missing user ID claim.") : Guid.Parse(userId);
        }
    }

}
