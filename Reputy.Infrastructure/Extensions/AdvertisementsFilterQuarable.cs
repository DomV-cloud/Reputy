using Reputy.Application.PaginationFilter;
using Reputy.Domain.Entities;
using Reputy.Domain.Enums;

namespace Reputy.Infrastructure.Extensions
{
    public static class AdvertisementsFilterQuarable
    {
        public static IQueryable<Advertisement> ApplyAdvertisementFilter(this IQueryable<Advertisement> query, AdvertisementFilter filter)
        {
            if (!String.IsNullOrEmpty(filter.Disposition))
            {
                query = query.Where(advertisement => advertisement.AdvertisementRealEstate.Disposition == Enum.Parse<Disposition>(filter.Disposition));
            }

            if (!String.IsNullOrEmpty(filter.City))
            {
                query = query.Where(advertisement => advertisement.AdvertisementRealEstate.Address.City.Equals(filter.City));
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(advertisement => advertisement.Price <= filter.MaxPrice);
            }

            if (filter.Size.HasValue)
            {
                query = query.Where(advertisement => advertisement.AdvertisementRealEstate.Size == filter.Size);
            }

            return query;
        }
    }
}
