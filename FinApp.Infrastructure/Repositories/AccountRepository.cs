
using FinApp.Domain.Aggregates;
using FinApp.Domain.Interfaces;
using FinApp.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Infrastructure.Repositories
{
    public class AccountRepository : IRepository<AccountAggregate>
    {
        private readonly FinanceDbContext _context;

        public AccountRepository(FinanceDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(AccountAggregate entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(AccountAggregate entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountAggregate>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AccountAggregate> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AccountAggregate entity)
        {
            throw new NotImplementedException();
        }
    }
}
