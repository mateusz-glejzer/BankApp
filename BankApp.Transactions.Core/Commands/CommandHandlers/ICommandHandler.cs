using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Transactions.Core.Commands.CommandHandlers;

public interface ICommandHandler<in T> where T : ICommand
{
    Task HandleAsync(T command, CancellationToken cancellationToken);
}