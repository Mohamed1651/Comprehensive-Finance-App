using FinApp.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<AccountDto>
    {
        public AccountDto AccountDto { get; }
        public CreateAccountCommand(AccountDto accountDto)
        {
            AccountDto = accountDto;
        }
    }
}
