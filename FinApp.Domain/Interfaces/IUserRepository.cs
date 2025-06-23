using FinApp.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Interfaces
{
    public interface IUserRepository : IRepository<UserAggregate>
    {
        Task<UserAggregate?> GetByUidAsync(string uid);
    }
}
