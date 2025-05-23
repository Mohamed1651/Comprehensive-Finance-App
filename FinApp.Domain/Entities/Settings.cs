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
        public string Language { get; private set; }
        public string Theme { get; private set; }
        public bool NotificationsEnabled { get; private set; }
        public Settings(string language, string theme, bool notificationsEnabled)
        {
            if (string.IsNullOrWhiteSpace(language))
                throw new DomainException("Language is required.");

            if (string.IsNullOrWhiteSpace(theme))
                throw new DomainException("Theme is required.");

            Language = language;
            Theme = theme;
            NotificationsEnabled = notificationsEnabled;
        }

        public Settings UpdateLanguage(string newLanguage) =>
            new Settings(newLanguage, Theme, NotificationsEnabled);

        public Settings UpdateTheme(string newTheme) =>
            new Settings(Language, newTheme, NotificationsEnabled);

        public Settings ToggleNotifications() =>
            new Settings(Language, Theme, !NotificationsEnabled);
    }
}
