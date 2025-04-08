using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Entities
{
    public class Budget
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Amount { get; set; }
        public Category Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
