﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Accounts;
using BankApp.BankAccounts.Domain.Accounts.Repository;
using BankApp.BankAccounts.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace BankApp.BankAccounts.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly AccountsDbContext _dbContext;

    public AccountRepository(AccountsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAccountAsync(Account account, CancellationToken cancellationToken = default)
    {
        await _dbContext.Accounts.AddAsync(account, cancellationToken);
    }

    public async Task<IReadOnlyList<Account>> GetUserAccounts(UserId userId,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Accounts.Where(account => account.UserId == userId)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Account> GetAccountByIdAsync(AccountId accountId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Accounts.Where(account => account.AccountId == accountId)
            .SingleAsync(cancellationToken: cancellationToken);
    }

    public void UpdateAccount(Account account, CancellationToken cancellationToken = default)
    {
        _dbContext.Accounts.Update(account);
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}