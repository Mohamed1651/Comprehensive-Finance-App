using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Queries.GetUserByUid
{
    public class GetUserByUidQuery : IRequest<int>
    {
        public string Uid { get; }
        public GetUserByUidQuery(string uid)
        {
            Uid = uid;
        }
    }
}
