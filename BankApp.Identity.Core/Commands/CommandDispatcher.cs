using System;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Identity.Core.Commands.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Identity.Core.Commands;

internal class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand
    {
        if (command is null)
        {
            return;
        }

        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
        await handler.HandleAsync(command, cancellationToken);
    }

    public async Task<TResponse> SendAsync<TCommand, TResponse>(TCommand command,
        CancellationToken cancellationToken = default) where TCommand : class, ICommand
    {
        if (command is null)
        {
            return default;
        }

        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResponse>>();
        return await handler.HandleAsync(command, cancellationToken);
    }
}