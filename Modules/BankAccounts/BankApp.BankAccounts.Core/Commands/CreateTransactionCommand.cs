using BankApp.BankAccounts.Domain.Accounts;
using BankApp.BankAccounts.Domain.Shared;

namespace BankApp.Wallets.Core.Commands;

public record CreateTransactionCommand(AccountId AccountId, UserId RecipientId, double Amount) : ICommand;