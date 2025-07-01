using Reputy.Application.Common.Interfaces.Persistance;
using Reputy.Domain.Entities;
using Reputy.Application.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Reputy.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly ReputyContext _context;

        public UserRepository(ReputyContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            using var context = _context;
            context.Users.Add(user);

            context.SaveChanges();
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }
    }
}
