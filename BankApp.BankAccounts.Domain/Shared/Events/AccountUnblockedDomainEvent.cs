using BankApp.BankAccounts.Domain.Accounts;

namespace BankApp.BankAccounts.Domain.Shared.Events;

public record AccountUnblockedDomainEvent(Account Account) : IDomainEvent;