using FinApp.Domain.Enums;
using FinApp.Domain.Interfaces;
using FinApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Entities
{
    public class Account : IEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public AccountType AccountType { get; private set; }
        public Balance Balance { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();
    }
}
