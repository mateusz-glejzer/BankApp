using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Transactions.Core.Commands.Dispatcher;

public interface ICommandDispatcher
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : class, ICommand;
}