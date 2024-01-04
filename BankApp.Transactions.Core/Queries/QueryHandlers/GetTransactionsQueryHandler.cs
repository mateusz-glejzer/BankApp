using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankApp.Transactions.Core.Transactions;

namespace BankApp.Transactions.Core.Queries.QueryHandlers;

public class GetTransactionsQueryHandler : IQueryHandler<GetTransactionsQuery, IReadOnlyList<Transaction>>
{
    private readonly ITransactionsRepository _transactionsRepository;

    public GetTransactionsQueryHandler(ITransactionsRepository transactionsRepository)
    {
        _transactionsRepository = transactionsRepository;
    }

    public async Task<IReadOnlyList<Transaction>> HandleAsync(GetTransactionsQuery query,
        CancellationToken cancellationToken = default)
    {
        return await _transactionsRepository.GetTransactionsByAccountId(query.AccountId, query.Page, query.ItemsPerPage,
            cancellationToken);
    }
}