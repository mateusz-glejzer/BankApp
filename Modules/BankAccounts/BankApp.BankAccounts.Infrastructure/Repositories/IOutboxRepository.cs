using System.Collections.Generic;
using System.Threading.Tasks;
using BankApp.BankAccounts.Infrastructure.Outbox;

namespace BankApp.BankAccounts.Infrastructure.Repositories;

public interface IOutboxRepository
{
    Task AddAsync(OutboxMessage outboxMessage);
    Task<IReadOnlyList<OutboxMessage>> GetUnsentAsync();
    void Update(OutboxMessage outboxMessage);

    Task SaveChangesAsync();
}