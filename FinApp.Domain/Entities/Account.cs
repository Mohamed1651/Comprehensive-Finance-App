using FinApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public double Balance { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
