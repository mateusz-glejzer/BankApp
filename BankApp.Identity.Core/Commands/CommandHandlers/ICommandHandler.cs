﻿using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Identity.Core.Commands.CommandHandlers;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<in TCommand, TResult> where TCommand : class, ICommand
{
    Task<TResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}