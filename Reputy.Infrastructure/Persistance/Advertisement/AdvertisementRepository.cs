using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Reputy.Application.Common.Interfaces.Persistance;
using Reputy.Application.DatabaseContext;
using Reputy.Application.Pagination;
using Reputy.Application.PaginationFilter;
using Reputy.Infrastructure.Extensions;
using System.Linq;

namespace Reputy.Infrastructure.Persistance.Advertisement
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly ReputyContext _context;

        public AdvertisementRepository(ReputyContext ctx)
        {
            _context = ctx;
        }

        public async Task<PagedResponse<List<Domain.Entities.Advertisement>>> GetAdvertisementsByFilterAsync(AdvertisementFilter filter)
        {
            var query = _context.Advertisements
                        .Include(a => a.Images)
                        .Include(a => a.Landlord)
                        .Include(a => a.AdvertisementRealEstate)
                        .ThenInclude(re => re.Address)
                        .AsQueryable()
                        .ApplyAdvertisementFilter(filter);

            var total = _context.Advertisements.Count();

            var data = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResponse<List<Domain.Entities.Advertisement>>(data, filter.PageNumber, filter.PageSize, total);
        }

        public async Task<List<Domain.Entities.Advertisement>> GetAllAdvertisementsAsync()
        {
            return await _context.Advertisements
                .AsNoTracking()
                .Include(a => a.AdvertisementRealEstate)
                .ToListAsync();
        }

        public async Task<List<string>> GetAllDispositionsAsync()
        {
            return await _context.AdvertisementRealEstates
                .AsNoTracking()
                .Select(re => re.Disposition.ToString())
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<string>> GetAllCitiesAsync()
        {
            return await _context.Addresses
                .AsNoTracking()
                .GroupBy(a => a.City)
                .Select(g => g.Key)
                .ToListAsync();
        }

        public async Task<int> GetMaxPricesAsync()
        {
            return await _context.Advertisements.MaxAsync(a => a.Price);
        }

        public async Task<int> GetMinPricesAsync()
        {
            return await _context.Advertisements.MinAsync(a => a.Price);
        }

        public async Task<List<Domain.Entities.Advertisement>> GetUserAdvertisementsAsync(Guid userId)
        {
            return await _context.Advertisements
                .AsNoTracking()
                .Include(a => a.AdvertisementRealEstate)
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }

        public async Task<Domain.Entities.Advertisement> GetAdvertisementByIdAsync(Guid id)
        {
            var advertisementDetail = await _context.Advertisements
                .Include(a => a.AdvertisementRealEstate)
                    .ThenInclude(re => re.Address)
                .Include(a => a.Landlord)
                .Include (a => a.Images)
                .FirstOrDefaultAsync(a => a.ID == id);

            if (advertisementDetail == null)
            {
                return new();
            }

            return advertisementDetail;
        }
    }
}
