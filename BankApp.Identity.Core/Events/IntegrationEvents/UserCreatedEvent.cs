using BankApp.Identity.Domain.User;

namespace BankApp.Identity.Core.Events.IntegrationEvents;

public class UserCreatedEvent : IEvent
{
    public UserId UserId { get; set; }
}