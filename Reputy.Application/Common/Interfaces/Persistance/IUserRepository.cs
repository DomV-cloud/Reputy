using Reputy.Domain.Entities;

namespace Reputy.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);

        void Add(User user);
    }
}
