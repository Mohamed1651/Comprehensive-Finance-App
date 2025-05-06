using FinApp.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {
        public GetUsersQuery() { }
    }
}
