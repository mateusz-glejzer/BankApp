using System.Threading;
using System.Threading.Tasks;
using BankApp.Transactions.Core.Transactions;

namespace BankApp.Transactions.Core.Events.EventHandlers;

public class TransactionCreatedEventHandler : IEventHandler<TransactionCreatedEvent>
{
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TransactionCreatedEventHandler(ITransactionsRepository transactionsRepository, IUnitOfWork unitOfWork)
    {
        _transactionsRepository = transactionsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(TransactionCreatedEvent @event, CancellationToken cancellationToken = default)
    {
        await _transactionsRepository.AddTransactionAsync(@event.Transaction);
        await _unitOfWork.SaveAsync(cancellationToken);
    }
}