using FinApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Entities
{
    public class Forecast : IEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Month {  get; set; }
        public double PredictedExpense { get; set; }
        public double PredictedIncome { get; set; }
    }
}
