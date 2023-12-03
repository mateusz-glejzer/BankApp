using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankApp.BankAccounts.Domain.Accounts.Repository;
using BankApp.Wallets.Core.Events.DomainEvents;

namespace BankApp.Wallets.Core.Commands.CommandHandlers;

public class CreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMessageBroker _messageBroker;

    public CreateTransactionCommandHandler(IAccountRepository accountRepository, IMessageBroker messageBroker)
    {
        _accountRepository = accountRepository;
        _messageBroker = messageBroker;
    }

    public async Task HandleAsync(CreateTransactionCommand command, CancellationToken cancellationToken = default)
    {
        var account = await _accountRepository.GetAccountByIdAsync(command.AccountId, cancellationToken);
        account.CreateTransaction(command.RecipientId, command.Amount);
        var events = account.DomainEvents
            .Select(@event => @event.MapToPublicEvent());
        await _messageBroker.PublishAsync(events);
    }
}