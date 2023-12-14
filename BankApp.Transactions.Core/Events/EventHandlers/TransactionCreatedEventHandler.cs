using System.Threading;
using System.Threading.Tasks;

namespace BankApp.Transactions.Core.Events.EventHandlers;

public class TransactionCreatedEventHandler : IEventHandler<TransactionCreatedEvent>
{
    private readonly ITransactionsRepository _transactionsRepository;

    public TransactionCreatedEventHandler(ITransactionsRepository transactionsRepository)
    {
        _transactionsRepository = transactionsRepository;
    }

    public async Task HandleAsync(TransactionCreatedEvent @event, CancellationToken cancellationToken = default)
    {
        await _transactionsRepository.AddTransactionAsync(@event.Transaction);
    }
}