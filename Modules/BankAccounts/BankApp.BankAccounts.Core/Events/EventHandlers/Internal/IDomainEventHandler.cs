using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Shared.Events;

namespace BankApp.Wallets.Core.Events.EventHandlers.Internal;

public interface IDomainEventHandler<in TEvent> where TEvent : class, IDomainEvent
{
    Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);
}