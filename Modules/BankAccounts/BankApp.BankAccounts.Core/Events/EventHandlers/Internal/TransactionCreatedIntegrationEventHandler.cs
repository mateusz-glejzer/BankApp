using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Wallets.Core.Events.IntegrationEvents.Internal;
using Newtonsoft.Json;

namespace BankApp.Wallets.Core.Events.EventHandlers.Internal;

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