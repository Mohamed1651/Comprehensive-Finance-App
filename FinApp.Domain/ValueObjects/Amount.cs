using FinApp.Domain.Exceptions;

namespace FinApp.Domain.ValueObjects
{
    public record Amount
    {
        public double Value { get; }
        private Amount() { }
        private Amount(double value) 
        {
            Value = value;
        }

        public static Amount Create(double value)
        {
            if(value < 0 || value > double.MaxValue)
                throw new DomainException("value");
            return new Amount(value);
        }
    }
}