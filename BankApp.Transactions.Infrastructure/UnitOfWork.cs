using System.Threading;
using System.Threading.Tasks;
using BankApp.Transactions.Core.Transactions;

namespace BankApp.Transactions.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly TransactionsDbContext _transactionsDbContext;

    public UnitOfWork(TransactionsDbContext transactionsDbContext)
    {
        _transactionsDbContext = transactionsDbContext;
    }

    public async Task DoAsync(CancellationToken cancellationToken)
    {
        await _transactionsDbContext.SaveChangesAsync(cancellationToken);
    }
}