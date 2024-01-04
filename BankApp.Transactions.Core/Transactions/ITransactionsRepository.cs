using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Transactions.Core.Shared;

namespace BankApp.Transactions.Core.Transactions;

public interface ITransactionsRepository
{
    Task AddTransactionAsync(Transaction transaction);
    Task<Transaction> GetTransactionById(Guid transactionId);

    Task<IReadOnlyList<Transaction>> GetTransactionsByAccountId(AccountId accountId, int page, int itemsPerPage,
        CancellationToken cancellationToken);
}