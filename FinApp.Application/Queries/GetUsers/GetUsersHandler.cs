using FinApp.Application.Dtos;
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
        private readonly IRepository<User> _userRepository;

        public GetUsersHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            List<UserDto> userDtos = new List<UserDto>();
            foreach(var user in users)
            {
                UserDto userDto = new UserDto(user.Id, user.Name, user.Email);
                userDtos.Add(userDto);
            }
            return userDtos;
        }
    }
}
