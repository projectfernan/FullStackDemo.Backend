using AutoMapper;
using FullStackDemo.ApplicationService.DTOs.MobileSuits;
using FullStackDemo.Domain.Entities.MobileSuits;

namespace FullStackDemo.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MobileSuit, MobileSuitDto>().ReverseMap();
            CreateMap<MobileSuitPaginated, MobileSuitPaginatedDto>().ReverseMap();
        }
    }
}
