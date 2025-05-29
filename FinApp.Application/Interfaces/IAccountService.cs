using FinApp.Domain.Aggregates;
using FinApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<AccountAggregate> GetAccounts();
        IEnumerable<AccountAggregate> GetAccountsByUser(int userId);
        AccountAggregate GetAccount(int id);
        void CreateAccount(AccountAggregate account);
        void UpdateAccount(AccountAggregate account);
        void DeleteAccount(int id);
    }
}
