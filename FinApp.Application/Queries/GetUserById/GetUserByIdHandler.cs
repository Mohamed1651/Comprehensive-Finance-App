using AutoMapper;
using FinApp.Application.Dtos;
using FinApp.Application.Interfaces;
using MediatR;

namespace FinApp.Application.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUser(request.Id);
            var dto = _mapper.Map<UserDto>(user);
            return dto;
        }
    }

}
