using FinApp.Domain.Entities;
using FinApp.Domain.Exceptions;
using FinApp.Domain.Interfaces;
using FinApp.Domain.ValueObjects;

namespace FinApp.Domain.Aggregates
{
    public class User : IEntity
    {
        public int Id { get; }
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Settings Settings { get; private set; }
        public ICollection<Account> Accounts { get; private set; } = new List<Account>();
        public ICollection<Budget> Budgets { get; private set; } = new List<Budget>();
        public ICollection<Report>? Reports { get; private set; }
        public User(string name, string email, Settings settings)
        {
            Name = name;
            Email = Email.Create(email);
            Settings = settings ?? throw new DomainException(nameof(settings));
        }
        public void UpdateEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
            {
                throw new DomainException("Invalid email.");
            }
            Email = Email.Create(newEmail);
        }
        public void UpdateSettings(Settings newSettings)
        {
            Settings = newSettings ?? throw new DomainException(nameof(newSettings));
        }
    }
}
