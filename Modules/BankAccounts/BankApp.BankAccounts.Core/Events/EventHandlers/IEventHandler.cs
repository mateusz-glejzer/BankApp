using System.Threading;
using System.Threading.Tasks;

namespace BankApp.BankAccounts.Core.Events.EventHandlers;

public interface IEventHandler<in T> where T : IEvent
{
    Task HandleAsync(T @event, CancellationToken cancellationToken);
}