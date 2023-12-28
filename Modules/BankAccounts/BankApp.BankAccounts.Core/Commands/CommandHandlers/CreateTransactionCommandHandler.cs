using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Accounts.Repository;
using BankApp.Wallets.Core.Events.Dispatcher;
using BankApp.Wallets.Core.Events.DomainEvents;

namespace BankApp.Wallets.Core.Commands.CommandHandlers;

public class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEventDispatcher _eventDispatcher;

    public CreateTransactionCommandHandler(IAccountRepository accountRepository, IEventDispatcher eventDispatcher)
    {
        _accountRepository = accountRepository;
        _eventDispatcher = eventDispatcher;
    }

    public async Task HandleAsync(CreateTransactionCommand command, CancellationToken cancellationToken = default)
    {
        var account = await _accountRepository.GetAccountByIdAsync(command.AccountId, cancellationToken);
        account.CreateTransaction(command.RecipientId, command.Amount);
        var events = account.DomainEvents
            .Select(@event => @event.MapToPublicEvent());
        await _eventDispatcher.DispatchAsync(events, cancellationToken);
    }
}