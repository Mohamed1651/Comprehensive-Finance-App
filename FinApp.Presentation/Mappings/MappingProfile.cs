using AutoMapper;
using FinApp.Domain.Entities;
using FinApp.Presentation.Dtos;

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
