using FinApp.Domain.Interfaces;
using FinApp.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Entities
{
    public class Budget : IEntity
    {
        public int Id { get; set; }
        public Amount Amount { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public Category? Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private Budget() { }
        public Budget(double amount, int categoryId, int userId) 
        {
            Amount = Amount.Create(amount);
            CategoryId = categoryId;
            UserId = userId;
            StartDate = DateTime.UtcNow;
            EndDate = DateTime.UtcNow;
        }
    }
}
