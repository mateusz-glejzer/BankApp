using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Core.Events.Dispatcher;
using BankApp.BankAccounts.Core.Events.DomainEvents;
using BankApp.BankAccounts.Domain.Accounts;
using BankApp.BankAccounts.Domain.Accounts.Repository;

namespace BankApp.BankAccounts.Core.Commands.CommandHandlers;

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
        await _accountRepository.SaveAsync();
        await _eventDispatcher.DispatchAsync(
            newAccount.DomainEvents.Select(domainEvent => domainEvent.MapToPublicEvent()),
            cancellationToken);
    }
}