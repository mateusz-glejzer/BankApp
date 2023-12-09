using BankApp.BankAccounts.Domain.Shared;

namespace BankApp.Wallets.Core.Queries;

public record GetUserAccountsQuery(UserId UserId) : IQuery;