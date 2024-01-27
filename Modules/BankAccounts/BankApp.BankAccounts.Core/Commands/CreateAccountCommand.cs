using BankApp.BankAccounts.Domain.Shared;

namespace BankApp.BankAccounts.Core.Commands;

public record CreateAccountCommand(UserId OwnerId, Currency Currency) : ICommand;