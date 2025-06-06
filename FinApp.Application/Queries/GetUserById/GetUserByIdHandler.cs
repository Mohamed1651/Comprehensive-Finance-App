using AutoMapper;
using FinApp.Application.Dtos;
using FinApp.Domain.Aggregates;
using FinApp.Domain.Interfaces;
using MediatR;

namespace FinApp.Application.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<UserAggregate> _userRepository;

        public GetUserByIdHandler(IMapper mapper, IRepository<UserAggregate> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            var dto = _mapper.Map<UserDto>(user);
            return dto;
        }
    }

}
