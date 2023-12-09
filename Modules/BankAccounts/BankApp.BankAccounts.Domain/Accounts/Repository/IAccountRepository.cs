using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Shared;

namespace BankApp.BankAccounts.Domain.Accounts.Repository;

public interface IAccountRepository
{
    Task AddAccountAsync(Account account, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Account>> GetUserAccounts(UserId userId, CancellationToken cancellationToken = default);
    Task<Account> GetAccountByIdAsync(AccountId accountId, CancellationToken cancellationToken = default);
    void UpdateAccount(Account account, CancellationToken cancellationToken = default);
    Task SaveAsync();
}