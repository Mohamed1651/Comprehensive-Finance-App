using FinApp.Domain.Common.Entities;
using FinApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        IEnumerable<Account> GetAccountsByUser(int userId);
        Account GetAccount(int id);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(int id);
    }
}
