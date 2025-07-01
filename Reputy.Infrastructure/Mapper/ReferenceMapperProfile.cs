using AutoMapper;
using Reputy.Contracts.Reference;
using Reputy.Domain.Entities;

namespace Reputy.Infrastructure.Mapper
{
    public class ReferenceMapperProfile : Profile
    {
        public ReferenceMapperProfile()
        {
            CreateMap<Reference, ReferenceResponse>();
        }
    }
}
