using System.Threading.Tasks;

namespace BankApp.Identity.Core.Events.EventHandlers;

public interface IEventHandler<in T> where T : IEvent
{
    Task HandleAsync(T @event);
}