using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Transactions.Core.Transactions;

public interface IUnitOfWork
{
    Task DoAsync(CancellationToken cancellationToken);
}