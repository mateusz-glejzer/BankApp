using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Shared.Events;
using BankApp.Wallets.Core.Events.DomainEvents;
using BankApp.Wallets.Core.Events.IntegrationEvents;

namespace BankApp.Wallets.Core.Events.EventHandlers.Internal;

public class TransactionCreatedEventHandler : IDomainEventHandler<TransactionCreatedDomainEvent>
{
    private readonly IIntegrationEventDispatcher _eventDispatcher;

    public TransactionCreatedEventHandler(IIntegrationEventDispatcher eventDispatcher)
    {
        _eventDispatcher = eventDispatcher;
    }


    public async Task HandleAsync(TransactionCreatedDomainEvent @event, CancellationToken cancellationToken = default)
    {
        await _eventDispatcher.PublishAsync(@event.MapToPublicEvent(), cancellationToken);
    }
}