using FinApp.Domain.Common.Enums;
using FinApp.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Common.Entities
{
    public class Transaction : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public TransactionType Type { get; set; }

        public int? AccountId { get; set; }
        public ICollection<CategoryTransaction> CategoryTransaction { get; set; } = new List<CategoryTransaction>();
    }
}
