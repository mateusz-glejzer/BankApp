using BankApp.BankAccounts.Domain.Shared;

namespace BankApp.BankAccounts.Core.Events.IntegrationEvents.External;

public class UserCreatedEvent : IEvent
{
    public UserId UserId { get; set; }
}