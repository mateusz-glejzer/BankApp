using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Wallets.Core.Queries.QueryHandlers;

public interface IQueryHandler<in TQuery, TResponse> where TQuery :
    class, IQuery
{
    Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}