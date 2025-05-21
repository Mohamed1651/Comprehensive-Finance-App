using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Common.Entities
{
    public class CategoryTransaction
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
