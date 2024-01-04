using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Transactions.Core;
using BankApp.Transactions.Core.Exceptions;
using BankApp.Transactions.Core.Shared;
using BankApp.Transactions.Core.Transactions;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Transactions.Infrastructure.Repositories;

public class TransactionsRepository : ITransactionsRepository
{
    private readonly TransactionsDbContext _dbContext;

    public TransactionsRepository(TransactionsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddTransactionAsync(Transaction transaction)
    {
        await _dbContext.AddAsync(transaction);
    }

    public async Task<Transaction> GetTransactionById(Guid transactionId)
    {
        var transaction = await _dbContext.Transactions.FindAsync(transactionId);
        if (transaction is null)
        {
            throw new TransactionDoesNotExistsException(transactionId);
        }

        return transaction;
    }

    public async Task<IReadOnlyList<Transaction>> GetTransactionsByAccountId(AccountId accountId, int page,
        int itemsPerPage,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Transactions.Where(transaction =>
                transaction.RecipientAccountId.Id == accountId || transaction.SenderAccountId.Id == accountId)
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage).OrderBy(transaction => transaction.Date)
            .ToListAsync(cancellationToken);
    }
}