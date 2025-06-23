using FinApp.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace FinApp.Domain.Aggregates
{
    public record ColorHex
    {
        public string Value { get; }


        private ColorHex() { }
        private ColorHex(string value)
        {
            Value = value;
        }

        private static bool IsValidHexColor(string hex)
        {
            if (string.IsNullOrEmpty(hex)) return false;

            var regex = new Regex("^#(?:[0-9a-fA-F]{3}){1,2}$");

            return regex.IsMatch(hex);
        }

        public static ColorHex Create(string value)
        {
            if (IsValidHexColor(value) == false) throw new DomainException("Invalid hex value.");
            return new ColorHex(value);
        }
    }
}