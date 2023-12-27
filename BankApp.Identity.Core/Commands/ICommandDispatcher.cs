using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Identity.Core.Commands;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;

    Task<TResponse> SendAsync<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;
}