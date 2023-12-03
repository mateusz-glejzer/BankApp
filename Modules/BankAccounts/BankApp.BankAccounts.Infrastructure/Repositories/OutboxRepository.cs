using System.Threading.Tasks;
using BankApp.Wallets.Infrastructure.Outbox;

namespace BankApp.Wallets.Infrastructure.Repositories;

public class OutboxRepository
{
    public Task AddAsync(OutboxMessage outboxMessage)
    {
        throw new System.NotImplementedException();
    }
}