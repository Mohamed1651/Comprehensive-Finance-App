using AutoMapper;
using FinApp.Application.Dtos;
using FinApp.Domain.Users.Entities;

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
