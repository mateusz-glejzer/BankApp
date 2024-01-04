using BankApp.BankAccounts.Domain.Accounts;
using BankApp.BankAccounts.Domain.Shared;

namespace BankApp.Wallets.Core.Commands;

public record CreateTransactionCommand(AccountId AccountId, AccountId RecipientAccountId, double Amount) : ICommand;