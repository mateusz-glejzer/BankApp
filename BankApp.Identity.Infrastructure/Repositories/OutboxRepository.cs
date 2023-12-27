using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Identity.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Identity.Infrastructure.Repositories;

public class OutboxRepository : IOutboxRepository
{
    private readonly IdentityDbContext _identityDbContext;

    public OutboxRepository(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }

    public async Task AddAsync(OutboxMessage outboxMessage)
    {
        await _identityDbContext.OutboxMessages.AddAsync(outboxMessage);
    }

    public async Task<IReadOnlyList<OutboxMessage>> GetUnsentAsync()
    {
        return await _identityDbContext.OutboxMessages.Where(outboxMessage => outboxMessage.ProcessedAt == null)
            .ToListAsync();
    }

    public void Update(OutboxMessage outboxMessage)
    {
        _identityDbContext.OutboxMessages.Update(outboxMessage);
    }

    public async Task SaveChangesAsync()
    {
        await _identityDbContext.SaveChangesAsync();
    }
}