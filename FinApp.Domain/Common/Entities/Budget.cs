using FinApp.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Common.Entities
{
    public class Budget : IEntity
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public Category? Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
