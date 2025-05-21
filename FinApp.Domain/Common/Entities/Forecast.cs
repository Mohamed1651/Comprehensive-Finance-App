using FinApp.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Common.Entities
{
    public class Forecast : IEntity
    {
        public int Id { get; set; }
        public DateTime Month { get; set; }
        public double PredictedExpense { get; set; }
        public double PredictedIncome { get; set; }
    }
}
