using Reputy.Domain.Entities;

namespace Reputy.Application.Services.Authentication
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
