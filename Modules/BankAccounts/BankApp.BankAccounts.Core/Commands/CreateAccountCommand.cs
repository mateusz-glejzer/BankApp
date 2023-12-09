using BankApp.BankAccounts.Domain.Shared;

namespace BankApp.Wallets.Core.Commands;

public record CreateAccountCommand(UserId OwnerId, Currency Currency) : ICommand;