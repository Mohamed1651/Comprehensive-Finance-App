using AutoMapper;
using FinApp.Domain.Entities;
using FinApp.Application.Dtos;

namespace FinApp.Presentation.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
