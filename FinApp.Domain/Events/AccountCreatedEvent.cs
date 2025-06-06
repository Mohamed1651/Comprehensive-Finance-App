using FinApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Events
{
    public class AccountCreatedEvent : IDomainEvent
    {
        public int AccountId { get; }
        public int UserId { get; }
        public AccountCreatedEvent(int accountId, int userId)
        {
            AccountId = accountId;
            UserId = userId;
        }
    }
}
