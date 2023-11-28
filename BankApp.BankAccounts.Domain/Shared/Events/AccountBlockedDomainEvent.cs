using BankApp.BankAccounts.Domain.Accounts;

namespace BankApp.BankAccounts.Domain.Shared.Events;

public record AccountBlockedDomainEvent(Account Account) : IDomainEvent;