using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Wallets.Core.Queries;

public interface IQueryDispatcher
{
    Task<TResponse> GetAsync<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : class, IQuery;
}