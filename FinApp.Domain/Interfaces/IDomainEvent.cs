﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Domain.Interfaces
{
    public interface IDomainEvent : INotification
    {
    }
}
