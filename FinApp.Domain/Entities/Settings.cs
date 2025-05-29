using FinApp.Domain.Exceptions;
using FinApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Entities
{
    public class Settings : IEntity
    {
        public int Id { get; }
        public string Language { get; private set; } = "en";
        public bool Darkmode { get; private set; } = false;
        public bool NotificationsEnabled { get; private set; } = false;

        public Settings() { }
        public Settings(string language, bool darkmode, bool notificationsEnabled)
        {
            if (string.IsNullOrWhiteSpace(language))
                throw new DomainException("Language is required.");

            Language = language;
            Darkmode = darkmode;
            NotificationsEnabled = notificationsEnabled;
        }

        public Settings UpdateLanguage(string newLanguage) =>
            new Settings(newLanguage, Darkmode, NotificationsEnabled);

        public Settings ToggleDarkmode() =>
            new Settings(Language, !Darkmode, NotificationsEnabled);

        public Settings ToggleNotifications() =>
            new Settings(Language, Darkmode, !NotificationsEnabled);
    }
}
