using AutoMapper;
using FinApp.Application.Dtos;
using FinApp.Domain.Aggregates;
using FinApp.Domain.Entities;
using FinApp.Domain.Interfaces;
using MediatR;

namespace FinApp.Application.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<UserAggregate> _userRepository;

        public CreateUserHandler(IMapper mapper, IRepository<UserAggregate> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var dto = request.UserDto;
            Settings settings = new Settings(0,"en", false, false);
            var newUser = new UserAggregate(dto.Uid, dto.Name, dto.Email, settings);
            await _userRepository.AddAsync(newUser);
            var newUserDto = _mapper.Map<UserDto>(newUser);
            return newUserDto;
        }
    }
}
