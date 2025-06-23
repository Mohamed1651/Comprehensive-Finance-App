using FinApp.Application.Dtos;
using FinApp.Domain.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public UserDto UserDto { get; }
        public CreateUserCommand(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}
