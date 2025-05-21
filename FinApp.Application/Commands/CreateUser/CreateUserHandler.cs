using FinApp.Domain.Common.Interfaces;
using FinApp.Domain.Users.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, int>
    {
        private IRepository<User> _userRepository;

        public CreateUserHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name, request.Email);
            await _userRepository.AddAsync(user);
            return user.Id;
        }
    }
}
