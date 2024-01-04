using System.Collections.Generic;
using BankApp.Transactions.Core.Shared;
using BankApp.Transactions.Core.Transactions;

namespace BankApp.Transactions.Core.Queries;

public record GetTransactionsQuery(AccountId AccountId, int Page, int ItemsPerPage)
    : IQuery<IReadOnlyList<Transaction>>;