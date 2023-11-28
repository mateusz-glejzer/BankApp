using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Wallets.Core.Events;

public interface IEventDispatcher
{
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
        where TEvent : class, IEvent;
}