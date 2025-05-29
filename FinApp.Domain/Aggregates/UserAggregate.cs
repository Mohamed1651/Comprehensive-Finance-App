using FinApp.Domain.Entities;
using FinApp.Domain.Exceptions;
using FinApp.Domain.Interfaces;
using FinApp.Domain.ValueObjects;
using System.Xml.Linq;

namespace FinApp.Domain.Aggregates
{
    public class UserAggregate : IAggregateRoot
    {
        public int Id { get; private set; }
        public string Uid { get; private set; }
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Settings Settings { get; private set; }
        public IReadOnlyCollection<AccountAggregate> Accounts => _accounts.AsReadOnly();
        private readonly List<AccountAggregate> _accounts = new List<AccountAggregate>();

        public UserAggregate(string uid, string name, string email, Settings settings)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be empty.");

            Uid = uid;
            Name = name;
            Email = Email.Create(email);
            Settings = settings;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName) || Name.Equals(newName)) throw new DomainException("Name cannot be null or the same.");
            Name = newName;
        }

        public void UpdateEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                throw new DomainException("Email cannot be empty.");

            Email = Email.Create(newEmail);
        }

        public void ChangeSettings(Settings newSettings)
        {
            Settings = newSettings ?? throw new DomainException(nameof(newSettings));
        }

        public void AddAccount(AccountAggregate account)
        {
            if (account == null) throw new DomainException("Account cannot be null.");
            if (_accounts.Any(a => a.Id == account.Id)) throw new DomainException("Account already exists.");
            _accounts.Add(account);
        }

    }
}
