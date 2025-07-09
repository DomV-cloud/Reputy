using Reputy.Domain.Entities;

namespace Reputy.Contracts.Authentication
{
    public record AuthenticationResponse
    (
        string FirstName,
        string LastName,
        string Email,
        string Role,
        string? AvatarUrl,
        decimal Rating,
        string Token
     );
}
