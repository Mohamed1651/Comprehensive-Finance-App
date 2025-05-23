using FinApp.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.ValueObjects
{
    public record Balance
    {
        public double Value { get; }

        public Balance(double value)
        {
            Value = value;
        }

        public static Balance Create(int value)
        {
            if (value < 0 || value > int.MaxValue)
            {
                throw new DomainException("Invalid balance amount.");
            }
            return new Balance(value);
        }
    }
}
