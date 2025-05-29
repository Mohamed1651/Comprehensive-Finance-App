using AutoMapper;
using FinApp.Application.Dtos;
using FinApp.Application.Interfaces;
using MediatR;

namespace FinApp.Application.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetCurrentUser();
            var dto = _mapper.Map<UserDto>(user);
            return dto;
        }
    }
}
