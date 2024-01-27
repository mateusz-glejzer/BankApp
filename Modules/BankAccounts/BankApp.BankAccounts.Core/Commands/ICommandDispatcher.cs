﻿using System.Threading;
using System.Threading.Tasks;

namespace BankApp.BankAccounts.Core.Commands;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;
}