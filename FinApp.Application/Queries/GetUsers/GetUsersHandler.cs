using AutoMapper;
using FinApp.Application.Dtos;
using FinApp.Application.Interfaces;
using FinApp.Domain.Aggregates;
using FinApp.Domain.Entities;
using FinApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Queries.GetUsers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUsersHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetUsers();
            var dtos = _mapper.Map<List<UserDto>>(users);
            return dtos;
        }
    }
}
