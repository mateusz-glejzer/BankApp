using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Transactions.Core.Queries.Dispatcher;

public interface IQueryDispatcher
{
    Task<TResult> GetAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
}