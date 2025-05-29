using AutoMapper;
using FinApp.Application.Dtos;
using FinApp.Domain.Aggregates;
using FinApp.Domain.Entities;

namespace FinApp.Presentation.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserAggregate, UserDto>().ReverseMap();
        }
    }
}
