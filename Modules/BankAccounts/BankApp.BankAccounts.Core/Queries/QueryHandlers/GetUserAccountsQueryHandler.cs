using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Wallets.Core.Queries.QueryHandlers;

public class GetUserAccountsQueryHandler : IQueryHandler<GetUserAccountsQuery>
{
    public Task HandleAsync(GetUserAccountsQuery query, CancellationToken cancellationToken = default)
    {
        throw new System.NotImplementedException();
    }
}