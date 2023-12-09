using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Accounts;
using BankApp.BankAccounts.Domain.Accounts.Repository;

namespace BankApp.Wallets.Core.Queries.QueryHandlers;

public class GetUserAccountsQueryHandler : IQueryHandler<GetUserAccountsQuery, IReadOnlyList<Account>>
{
    private readonly IAccountRepository _accountRepository;

    public GetUserAccountsQueryHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<IReadOnlyList<Account>> HandleAsync(GetUserAccountsQuery query,
        CancellationToken cancellationToken = default)
    {
        return await _accountRepository.GetUserAccounts(query.UserId, cancellationToken);
    }
}