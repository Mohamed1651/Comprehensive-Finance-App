﻿using FinApp.Domain.Aggregates;
using FinApp.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Events
{
    public class AccountCreatedEventHandler : INotificationHandler<AccountCreatedEvent>
    {
        private readonly IUserRepository _userRepository;

        public AccountCreatedEventHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(AccountCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(domainEvent.UserId);
            if (user == null) return;
            await _userRepository.UpdateAsync(user);
        }
    }
}
