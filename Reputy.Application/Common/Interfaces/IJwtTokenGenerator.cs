using Reputy.Domain.Entities;

namespace Reputy.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
