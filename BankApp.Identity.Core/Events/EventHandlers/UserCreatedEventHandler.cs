using System.Threading.Tasks;

namespace BankApp.Identity.Core.Events.EventHandlers;

public class UserCreatedEventHandler : IEventHandler<IntegrationEvents.UserCreatedEvent>
{
    private readonly IMessageBroker _messageBroker;

    public UserCreatedEventHandler(IMessageBroker messageBroker)
    {
        _messageBroker = messageBroker;
    }

    public async Task HandleAsync(IntegrationEvents.UserCreatedEvent @event)
    {
       await _messageBroker.PublishAsync("user-created", @event);
    }
}