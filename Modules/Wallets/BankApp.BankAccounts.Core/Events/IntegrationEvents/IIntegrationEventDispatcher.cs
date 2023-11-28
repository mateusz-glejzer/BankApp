using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Wallets.Core.Events.IntegrationEvents;

public interface IIntegrationEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : class, IEvent;
}