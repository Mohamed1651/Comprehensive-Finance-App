using AutoMapper;
using FinApp.Application.Dtos;
using FinApp.Domain.Aggregates;
using FinApp.Domain.Entities;
using FinApp.Domain.ValueObjects;

namespace FinApp.Presentation.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserAggregate, UserDto>().ReverseMap();
            CreateMap<AccountAggregate, AccountDto>().ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance.Value));
            CreateMap<AccountDto, AccountAggregate>().ForMember(dest => dest.Balance, opt => opt.MapFrom(src => new Balance(src.Balance)));
        }
    }
}
