using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.BankAccounts.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;

namespace BankApp.BankAccounts.Infrastructure.Repositories;

public class OutboxRepository : IOutboxRepository
{
    private readonly AccountsDbContext _accountsDbContext;

    public OutboxRepository(AccountsDbContext accountsDbContext)
    {
        _accountsDbContext = accountsDbContext;
    }

    public async Task AddAsync(OutboxMessage outboxMessage)
    {
        await _accountsDbContext.OutboxMessages.AddAsync(outboxMessage);
    }

    public async Task<IReadOnlyList<OutboxMessage>> GetUnsentAsync()
    {
        return await _accountsDbContext.OutboxMessages.Where(outboxMessage => outboxMessage.ProcessedAt == null)
            .ToListAsync();
    }

    public void Update(OutboxMessage outboxMessage)
    {
        _accountsDbContext.OutboxMessages.Update(outboxMessage);
    }

    public async Task SaveChangesAsync()
    {
        await _accountsDbContext.SaveChangesAsync();
    }
}