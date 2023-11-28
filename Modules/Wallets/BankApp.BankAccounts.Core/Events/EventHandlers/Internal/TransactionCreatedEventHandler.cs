using System.Threading;
using System.Threading.Tasks;
using BankApp.Wallets.Core.Events.IntegrationEvents;

namespace BankApp.Wallets.Core.Events.EventHandlers.Internal;

public class TransactionCreatedEventHandler : IEventHandler<TransactionCreatedIntegrationEvent>
{
    private readonly IEventDispatcher _eventDispatcher;

    public TransactionCreatedEventHandler(IEventDispatcher eventDispatcher)
    {
        _eventDispatcher = eventDispatcher;
    }

    public async Task HandleAsync(TransactionCreatedIntegrationEvent @event,
        CancellationToken cancellationToken = default)
    {
        await _eventDispatcher.PublishAsync(@event, cancellationToken);
    }
}