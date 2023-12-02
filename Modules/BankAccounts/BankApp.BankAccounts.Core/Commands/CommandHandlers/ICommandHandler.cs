using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Wallets.Core.Commands.CommandHandlers;

public interface ICommandHandler<in TCommand> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}