using AutoMapper;
using Reputy.Application.Pagination;
using Reputy.Contracts.Address;
using Reputy.Contracts.Advertisement;
using Reputy.Domain.Entities;

namespace Reputy.Infrastructure.Mapper
{
    public class AdvertisementMapperProfile : Profile
    {
        public AdvertisementMapperProfile()
        {
            CreateMap<PagedResponse<List<Advertisement>>, PagedResponse<List<AdvertisementResponse>>>();

            CreateMap<Advertisement, AdvertisementResponse>();
            CreateMap<AdvertisementRealEstate, AdvertisementRealEstateResponse>();
            CreateMap<Address, AdressResponse>();
        }
    }
}
