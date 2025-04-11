using FinApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ColorHex { get; set; }
        public ICollection<CategoryTransaction> CategoryTransactions { get; set; } = new List<CategoryTransaction>();
        public Budget Budget { get; set; }
    }
}
