using FinApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FinApp.Application.Dtos
{
    public class AccountDto
    {
        int Id { get; set; }
        public AccountType AccountType { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public int UserId { get; set; }
    }
}
