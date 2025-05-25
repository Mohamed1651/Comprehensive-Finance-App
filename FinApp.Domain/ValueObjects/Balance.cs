using FinApp.Domain.Exceptions;
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

        public static Balance Create(double value)
        {
            if (value < 0 || value > int.MaxValue)
                throw new DomainException("Invalid balance amount.");
            
            return new Balance(value);
        }

        public Balance Add(double value)
        {
            if(value < 0)
                throw new DomainException("Cannot deposit negative amount.");

            var newValue = Value + value;

            if(newValue > int.MaxValue)
                throw new DomainException("Maximum deposit capacity reached.");

            return Create(newValue);
        }

        public Balance Subtract(double value)
        {
            if (value < 0)
                throw new DomainException("Cannot withdraw negative amount");

            var newValue = Value - value;

            if (newValue < 0)
                throw new DomainException("Insufficient balance.");

            return Create(newValue);
        }
    }
}
