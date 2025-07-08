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

        public async Task<PagedResponse<List<Domain.Entities.Advertisement>>> GetAdvertisementsByFilter(AdvertisementFilter f)
        {
            var query = _context.Advertisements
                        .Include(a => a.AdvertisementRealEstate)
                        .ThenInclude(re => re.Address)
                        .AsQueryable()
                        .ApplyAdvertisementFilter(f);

            var total = _context.Advertisements.Count();

            var data = await query
                .Skip((f.PageNumber - 1) * f.PageSize)
                .Take(f.PageSize)
                .ToListAsync();

            return new PagedResponse<List<Domain.Entities.Advertisement>>(data, f.PageNumber, f.PageSize, total);
        }

        public async Task<List<Domain.Entities.Advertisement>> GetAllAdvertisementsAsync()
        {
            return await _context.Advertisements
                .AsNoTracking()
                .Include(a => a.AdvertisementRealEstate)
                .ToListAsync();
        }

        public async Task<List<string>> GetAllDispositions()
        {
            return await _context.AdvertisementRealEstates
                .AsNoTracking()
                .Select(re => re.Disposition.ToString())
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<string>> GetAllCities()
        {
            return await _context.Addresses
                .AsNoTracking()
                .GroupBy(a => a.City)
                .Select(g => g.Key)
                .ToListAsync();
        }

        public async Task<int> GetMaxPrices()
        {
            return await _context.Advertisements.MaxAsync(a => a.Price);
        }

        public async Task<int> GetMinPrices()
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
    }
}
