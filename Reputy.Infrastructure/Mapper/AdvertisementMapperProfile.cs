using AutoMapper;
using Reputy.Application.Pagination;
using Reputy.Contracts.Address;
using Reputy.Contracts.Advertisement;
using Reputy.Contracts.User;
using Reputy.Domain.Entities;

namespace Reputy.Infrastructure.Mapper
{
    public class AdvertisementMapperProfile : Profile
    {
        public AdvertisementMapperProfile()
        {
            CreateMap<PagedResponse<List<Advertisement>>, PagedResponse<List<AdvertisementResponse>>>();

            CreateMap<Advertisement, AdvertisementResponse>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Images.FirstOrDefault().Url));
          
            CreateMap<AdvertisementRealEstate, AdvertisementRealEstateResponse>();
            CreateMap<Address, AdressResponse>();
            CreateMap<User, LandLordResponse>();
        }
    }
}
