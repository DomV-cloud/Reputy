using Reputy.Application.PaginationFilter;
using Reputy.Domain.Entities;

namespace Reputy.Infrastructure.Extensions
{
    public static class AdvertisementsFilterQuarable
    {
        public static IQueryable<Advertisement> ApplyAdvertisementFilter(this IQueryable<Advertisement> query, AdvertisementFilter filter)
        {
            if (!String.IsNullOrEmpty(filter.Disposition))
            {
                query = query.Where(advertisement => advertisement.AdvertisementRealEstate.Disposition.Equals(filter.Disposition));
            }

            if (!String.IsNullOrEmpty(filter.City))
            {
                query = query.Where(advertisement => advertisement.AdvertisementRealEstate.Address.City.Equals(filter.City));
            }

            if (filter.Price.HasValue)
            {
                query = query.Where(advertisement => advertisement.Price == filter.Price);
            }

            if (filter.Size.HasValue)
            {
                query = query.Where(advertisement => advertisement.AdvertisementRealEstate.Size == filter.Size);
            }


            return query;
        }
    }
}
