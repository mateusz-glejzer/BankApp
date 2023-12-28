using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Wallets.Core.Events.Dispatcher;

public interface IEventDispatcher
{
    Task DispatchAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken);
}