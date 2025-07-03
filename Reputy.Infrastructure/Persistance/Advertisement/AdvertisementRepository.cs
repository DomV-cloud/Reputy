using Microsoft.EntityFrameworkCore;
using Reputy.Application.Common.Interfaces.Persistance;
using Reputy.Application.DatabaseContext;
using Reputy.Application.Pagination;
using Reputy.Application.PaginationFilter;
using Reputy.Infrastructure.Extensions;
using System.Linq;

namespace Reputy.Infrastructure.Persistance.Advertisement
{
    internal class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly ReputyContext _context;

        public AdvertisementRepository(ReputyContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<List<Domain.Entities.Advertisement>>> GetAdvertisementsByFilter(AdvertisementFilter filter)
        {
            var query = _context.Advertisements
                          .Include(a => a.AdvertisementRealEstate)
                          .AsQueryable()
                          .ApplyAdvertisementFilter(filter);

            var totalRecords = _context.Advertisements.Count();

            var pagedData = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResponse<List<Domain.Entities.Advertisement>>(pagedData, filter.PageNumber, filter.PageSize, totalRecords);
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
