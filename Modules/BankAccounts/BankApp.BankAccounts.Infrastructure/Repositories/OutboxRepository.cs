using System.Threading.Tasks;
using BankApp.BankAccounts.Infrastructure.Outbox;

namespace BankApp.BankAccounts.Infrastructure.Repositories;

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