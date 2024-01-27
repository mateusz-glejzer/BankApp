using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Core.Events.IntegrationEvents.Internal;

namespace BankApp.BankAccounts.Core.Events.EventHandlers.Internal;

public class TransactionCreatedIntegrationEventHandler : IEventHandler<TransactionCreatedIntegrationEvent>
{
    private readonly IMessageBroker _messageBroker;

    public TransactionCreatedIntegrationEventHandler(IMessageBroker messageBroker)
    {
        _messageBroker = messageBroker;
    }

    public async Task HandleAsync(TransactionCreatedIntegrationEvent @event, CancellationToken cancellationToken)
    {
        await _messageBroker.PublishAsync("transaction-created", @event);
    }
}