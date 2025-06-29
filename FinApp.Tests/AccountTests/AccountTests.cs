using AutoMapper;
using FinApp.Application.Commands.CreateAccount;
using FinApp.Application.Dtos;
using FinApp.Domain.Aggregates;
using FinApp.Domain.Entities;
using FinApp.Domain.Enums;
using FinApp.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Tests.AccountTests
{
    public class AccountTests
    {
        private readonly Mock<IRepository<AccountAggregate>> _accountRepositoryMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly CreateAccountHandler _createAccountHandler;
        public AccountTests()
        {
            _createAccountHandler = new CreateAccountHandler(_mapperMock.Object, _accountRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateAccount_WithValidUser_ReturnsAccount()
        {
            // Arrange
            var accountDto = new AccountDto()
            {
                Id = 0,
                AccountType = AccountType.DebitCard,
                Name = "Test Account",
                Balance = 1000.0,
                UserId = 0
            };
            var accountAggregate = new AccountAggregate(accountDto.Name, accountDto.AccountType, accountDto.Balance, accountDto.UserId, new List<Transaction>());
            var command = new CreateAccountCommand(accountDto);
            _mapperMock.Setup(m => m.Map<AccountDto>(It.IsAny<AccountAggregate>())).Returns(accountDto);
            // Act
            var result = await _createAccountHandler.Handle(command, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(accountDto.Name, result.Name);
            Assert.Equal(accountDto.AccountType, result.AccountType);
            Assert.Equal(accountDto.Balance, result.Balance);
            Assert.Equal(accountDto.UserId, result.UserId);
        }
    }
}
