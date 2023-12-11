using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankApp.BankAccounts.Infrastructure.Repositories;
using Newtonsoft.Json;

namespace BankApp.BankAccounts.Infrastructure.Outbox;

public class MessageOutbox : IMessageOutbox
{
    private readonly OutboxRepository _outboxRepository;

    public MessageOutbox(OutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public async Task SendAsync<T>(T message, Guid messageId) where T : class
    {
        var serializedMessage =JsonConvert.SerializeObject(message);
        await _outboxRepository.AddAsync(new OutboxMessage
        {
            MessageId = messageId,
            SerializedMessage = serializedMessage,
            MessageType = ((T)message)?.GetType().AssemblyQualifiedName,
            SentAt = DateTime.UtcNow
        });
    }

    public Task<IReadOnlyList<OutboxMessage>> GetUnsentAsync()
    {
        throw new NotImplementedException();
    }

    public Task ProcessAsync(OutboxMessage message)
    {
        throw new NotImplementedException();
    }
}