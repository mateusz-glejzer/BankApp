using System.Threading.Tasks;
using BankApp.Wallets.Infrastructure.Db;
using BankApp.Wallets.Infrastructure.Outbox;

namespace BankApp.Wallets.Infrastructure.Repositories;

public class OutboxRepository
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
}