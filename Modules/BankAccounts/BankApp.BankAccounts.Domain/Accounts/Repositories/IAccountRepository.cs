using System.Threading;
using System.Threading.Tasks;

namespace BankApp.BankAccounts.Domain.Accounts.Repositories;

public interface IAccountRepository
{
    Task AddAccount(Account account, CancellationToken cancellationToken = default);
    Task GetAccountById(AccountId accountId, CancellationToken cancellationToken = default);
    Task UpdateAccount(AccountId accountId, CancellationToken cancellationToken = default);
}