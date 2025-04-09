using FinApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Settings Settings { get; set; }
        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<Budget> Budgets { get; set; } = new List<Budget>();
        public List<Report> Reports { get; set; }
    }
}
