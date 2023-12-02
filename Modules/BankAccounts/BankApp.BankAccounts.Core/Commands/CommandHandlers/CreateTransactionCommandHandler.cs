using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Accounts.Repository;

namespace BankApp.Wallets.Core.Commands.CommandHandlers;

public class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand>
{
    private readonly IAccountRepository _accountRepository;

    public CreateTransactionCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task HandleAsync(CreateTransactionCommand command, CancellationToken cancellationToken = default)
    {
        var account = await _accountRepository.GetAccountByIdAsync(command.AccountId, cancellationToken);
        account.CreateTransaction(command.RecipientId, command.Amount);
    }
}