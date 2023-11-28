using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Shared.Events;
using BankApp.Wallets.Core.Events.DomainEvents;

namespace BankApp.Wallets.Core.Events.EventHandlers.Internal;

public class TransactionCreatedEventHandler : IDomainEventHandler<TransactionCreatedDomainEvent>
{
    private readonly IDomainEventDispatcher _eventDispatcher;

    public TransactionCreatedEventHandler(IDomainEventDispatcher eventDispatcher)
    {
        _eventDispatcher = eventDispatcher;
    }


    public async Task HandleAsync(TransactionCreatedDomainEvent @event, CancellationToken cancellationToken = default)
    {
        await _eventDispatcher.PublishAsync(@event, cancellationToken);
    }
}