using BankApp.BankAccounts.Domain.Shared;

namespace BankApp.BankAccounts.Core.Queries;

public record GetUserAccountsQuery(UserId UserId) : IQuery;