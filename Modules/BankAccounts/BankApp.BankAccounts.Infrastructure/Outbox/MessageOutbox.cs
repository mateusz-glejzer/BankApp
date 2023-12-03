using System;
using System.Threading.Tasks;
using BankApp.Wallets.Infrastructure.Repositories;

namespace BankApp.Wallets.Infrastructure.Outbox;

public class MessageOutbox : IMessageOutbox
{
    private readonly OutboxRepository _outboxRepository;

    public MessageOutbox(OutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public async Task SendAsync<T>(T message, Guid messageId) where T : class
    {
        await _outboxRepository.AddAsync(new OutboxMessage
        {
            MessageId = messageId,
            Message = message,
            MessageType = ((T)message)?.GetType().AssemblyQualifiedName,
            SentAt = DateTime.UtcNow
        });
    }
}