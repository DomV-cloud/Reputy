using AutoMapper;
using Reputy.Contracts.Advertisement;
using Reputy.Domain.Entities;

namespace Reputy.Infrastructure.Mapper
{
    public class AdvertisementMapperProfile : Profile
    {
        public AdvertisementMapperProfile()
        {
            CreateMap<Advertisement, AdvertisementResponse>();
            CreateMap<AdvertisementRealEstate, AdvertisementRealEstateResponse>();
        }
    }
}
