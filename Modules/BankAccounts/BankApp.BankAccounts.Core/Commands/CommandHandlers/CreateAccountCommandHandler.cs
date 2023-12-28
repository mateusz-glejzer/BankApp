using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Accounts;
using BankApp.BankAccounts.Domain.Accounts.Repository;
using BankApp.Wallets.Core.Events.Dispatcher;
using BankApp.Wallets.Core.Events.DomainEvents;

namespace BankApp.Wallets.Core.Commands.CommandHandlers;

public class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEventDispatcher _eventDispatcher;

    public CreateAccountCommandHandler(IAccountRepository accountRepository, IEventDispatcher eventDispatcher)
    {
        _accountRepository = accountRepository;
        _eventDispatcher = eventDispatcher;
    }

    public async Task HandleAsync(CreateAccountCommand command, CancellationToken cancellationToken = default)
    {
        var newAccount = new Account(command.OwnerId, command.Currency);
        await _accountRepository.AddAccountAsync(newAccount, cancellationToken);
        await _eventDispatcher.DispatchAsync(
            newAccount.DomainEvents.Select(domainEvent => domainEvent.MapToPublicEvent()),
            cancellationToken);
    }
}