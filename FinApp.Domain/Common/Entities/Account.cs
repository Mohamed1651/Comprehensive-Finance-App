using FinApp.Domain.Common.Enums;
using FinApp.Domain.Common.Interfaces;
using FinApp.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Common.Entities
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
