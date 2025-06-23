
using FinApp.Domain.Aggregates;
using FinApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Queries.GetUserByUid
{
    public class GetUserByUidHandler : IRequestHandler<GetUserByUidQuery, int>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByUidHandler(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(GetUserByUidQuery request, CancellationToken cancellationToken)
        {
            UserAggregate user = await _userRepository.GetByUidAsync(request.Uid);
            return user.Id;
        }
    }
}
