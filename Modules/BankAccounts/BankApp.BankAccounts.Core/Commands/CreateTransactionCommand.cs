using BankApp.BankAccounts.Domain.Accounts;

namespace BankApp.BankAccounts.Core.Commands;

public record CreateTransactionCommand(AccountId AccountId, AccountId RecipientAccountId, double Amount)
    : ICommand;