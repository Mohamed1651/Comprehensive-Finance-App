using AutoMapper;
using FinApp.Application.Dtos;
using FinApp.Domain.Aggregates;
using FinApp.Domain.Entities;
using FinApp.Domain.Interfaces;
using MediatR;

namespace FinApp.Application.Commands.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, AccountDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AccountAggregate> _accountRepository;
        public CreateAccountHandler(IMapper mapper, IRepository<AccountAggregate> accountRepository)
        { 
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        public async Task<AccountDto> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var dto = request.AccountDto;
            var accountAggregate = new AccountAggregate(dto.Name, dto.AccountType, dto.Balance, dto.UserId, new List<Transaction>());
            await _accountRepository.AddAsync(accountAggregate);
            return _mapper.Map<AccountDto>(accountAggregate);
        }
    }
}
