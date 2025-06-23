using FinApp.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Entities
{
    public class CategoryTransaction
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
        public DateTime TransactionDate { get; set; }

        public CategoryTransaction(int categoryId)
        {
            if (categoryId <= 0)
                throw new DomainException("Invalid category ID.");

            CategoryId = categoryId;
            TransactionDate = DateTime.UtcNow;
        }
    }
}
