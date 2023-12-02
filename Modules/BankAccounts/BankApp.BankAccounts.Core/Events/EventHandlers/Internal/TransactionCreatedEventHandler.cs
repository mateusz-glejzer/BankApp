using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Accounts.Repository;
using BankApp.BankAccounts.Domain.Shared.Events;
using BankApp.Wallets.Core.Events.DomainEvents;
using BankApp.Wallets.Core.Events.IntegrationEvents;

namespace BankApp.Wallets.Core.Events.EventHandlers.Internal;

public class TransactionCreatedEventHandler : IEventHandler<TransactionCreatedDomainEvent>
{
    private readonly IIntegrationEventDispatcher _eventDispatcher;
    private readonly IAccountRepository _accountRepository;

    public TransactionCreatedEventHandler(IIntegrationEventDispatcher eventDispatcher,
        IAccountRepository accountRepository)
    {
        _eventDispatcher = eventDispatcher;
        _accountRepository = accountRepository;
    }


    public async Task HandleAsync(TransactionCreatedDomainEvent @event, CancellationToken cancellationToken = default)
    {
        _accountRepository.UpdateAccount(@event.Account, cancellationToken);

        await _eventDispatcher.PublishAsync(@event.MapToPublicEvent(), cancellationToken);
        await _accountRepository.SaveAsync();
    }
}