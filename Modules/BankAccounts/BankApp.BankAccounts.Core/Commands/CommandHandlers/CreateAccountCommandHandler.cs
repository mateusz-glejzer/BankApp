using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Accounts;
using BankApp.BankAccounts.Domain.Accounts.Repository;

namespace BankApp.Wallets.Core.Commands.CommandHandlers;

public class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand>
{
    private readonly IAccountRepository _accountRepository;

    public CreateAccountCommandHandler(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task HandleAsync(CreateAccountCommand command, CancellationToken cancellationToken = default)
    {
        var newAccount = new Account(command.OwnerId, command.Currency);
        await _accountRepository.AddAccountAsync(newAccount, cancellationToken);
    }
}