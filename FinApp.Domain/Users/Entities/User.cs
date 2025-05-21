using FinApp.Domain.Common.Entities;
using FinApp.Domain.Common.Interfaces;
using FinApp.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Users.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Settings? Settings { get; private set; }
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
        public ICollection<Report>? Reports { get; set; }
        public User(string name, string email, Settings settings)
        {
            Name = name;
            Email = Email.Create(email);
            Settings = settings;
        }
    }
}
