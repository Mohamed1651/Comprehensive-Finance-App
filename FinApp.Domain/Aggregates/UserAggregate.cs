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
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Settings Settings { get; private set; }

        public UserAggregate(string name, string email, Settings settings)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be empty.");

            Name = name;
            Email = Email.Create(email);
            Settings = settings;
        }

        public void UpdateEmail(string newEmail)
        {
            Email = Email.Create(newEmail);
        }

        public void ChangeSettings(Settings newSettings)
        {
            Settings = newSettings ?? throw new DomainException(nameof(newSettings));
        }
    }
}
