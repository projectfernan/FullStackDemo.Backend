using AutoMapper;
using FullStackDemo.ApplicationService.Commands.CommandModels.MobileSuits;
using FullStackDemo.ApplicationService.DTOs.MobileSuits;
using FullStackDemo.Domain.Entities.MobileSuits;

namespace FullStackDemo.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MobileSuit, MobileSuitDto>().ReverseMap();
            CreateMap<MobileSuit, CreateMobileSuitCommand>().ReverseMap();
            CreateMap<MobileSuit, UpdateMobileSuitCommand>().ReverseMap();
            CreateMap<MobileSuit, DeleteMobileSuitCommand>().ReverseMap();
            CreateMap<MobileSuitPaginated, MobileSuitPaginatedDto>().ReverseMap();
        }
    }
}
