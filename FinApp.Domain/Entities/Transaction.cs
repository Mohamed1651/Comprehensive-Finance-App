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
    public class Transaction : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Amount Amount { get; set; }
        public TransactionType Type { get; set; }
        public int AccountId { get; set; }
        public ICollection<CategoryTransaction> CategoryTransaction { get; set; } = new List<CategoryTransaction>();

        public Transaction(string title, string description, double amount, TransactionType type, int accountId, ICollection<CategoryTransaction> categoryTransaction)
        {
            Title = title;
            Description = description;
            Amount = Amount.Create(amount);
            Type = type;
            AccountId = accountId;
            CategoryTransaction = categoryTransaction;
        }
    }
}
