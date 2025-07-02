using Microsoft.EntityFrameworkCore;
using Reputy.Application.Common.Interfaces.Persistance;
using Reputy.Application.DatabaseContext;

namespace Reputy.Infrastructure.Persistance.Advertisement
{
    internal class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly ReputyContext _context;

        public AdvertisementRepository(ReputyContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.Advertisement>> GetAllAdvertisementsAsync()
        {
            return await _context.Advertisements
           .AsNoTracking()
             .Include(advertisement => advertisement.AdvertisementRealEstate)
             .ToListAsync();
        }

        public async Task<List<Domain.Entities.Advertisement>> GetUserAdvertisementsAsync(Guid userID)
        {
            return await _context.Advertisements
            .AsNoTracking()
              .Include(advertisement => advertisement.AdvertisementRealEstate)
              .Where(advertisement => advertisement.UserId == userID)
              .ToListAsync();
        }
    }
}
