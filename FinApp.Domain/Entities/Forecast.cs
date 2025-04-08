using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Entities
{
    public class Forecast
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Month {  get; set; }
        public double PredictedExpense { get; set; }
        public double PredictedIncome { get; set; }
    }
}
