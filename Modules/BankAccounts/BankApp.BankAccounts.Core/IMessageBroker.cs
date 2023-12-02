using System.Collections.Generic;
using System.Threading.Tasks;
using BankApp.Wallets.Core.Events;

namespace BankApp.Wallets.Core;

public interface IMessageBroker
{
    Task PublishAsync(IEnumerable<IEvent> events);
}