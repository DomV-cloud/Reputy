using Reputy.Application.Pagination;
using Reputy.Application.PaginationFilter;
using Reputy.Domain.Entities;

namespace Reputy.Application.Common.Interfaces.Persistance
{
    public interface IAdvertisementRepository
    {
        Task<List<Advertisement>> GetUserAdvertisementsAsync(Guid userID);

        Task<List<Advertisement>> GetAllAdvertisementsAsync();

        Task<PagedResponse<List<Advertisement>>> GetAdvertisementsByFilter(AdvertisementFilter filter);
    }
}
