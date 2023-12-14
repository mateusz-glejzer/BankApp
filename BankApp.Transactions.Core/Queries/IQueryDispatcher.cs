using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Transactions.Core.Queries;

public interface IQueryDispatcher
{
    Task GetAsync<TQuery>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : class, IQuery;
}