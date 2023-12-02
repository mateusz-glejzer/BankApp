using System.Threading;
using System.Threading.Tasks;

namespace BankApp.BankAccounts.Domain.Accounts.Repository;

public interface IAccountRepository
{
    Task AddAccount(Account account, CancellationToken cancellationToken = default);
    Task<Account> GetAccountByIdAsync(AccountId accountId, CancellationToken cancellationToken = default);
    void UpdateAccount(Account account, CancellationToken cancellationToken = default);
    Task SaveAsync();
}