using System.Threading;
using System.Threading.Tasks;

namespace BankApp.BankAccounts.Core.Queries.Dispatcher;

public interface IQueryDispatcher
{
    Task<TResponse> GetAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : class, IQuery;
}