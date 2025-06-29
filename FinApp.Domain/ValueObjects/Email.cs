﻿using FinApp.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string value)
        {
            if (string.IsNullOrEmpty(value) || !value.Contains("@"))
            {
                throw new DomainException("Invalid email format.");
            }
            string normalized = value.Trim().ToLowerInvariant();

            return new Email(normalized);
        }

        public bool EqualsString(string other)
        {
            return string.Equals(Value, other, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
