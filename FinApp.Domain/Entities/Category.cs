using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string ColorHex { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Budget budget { get; set; }
    }
}
