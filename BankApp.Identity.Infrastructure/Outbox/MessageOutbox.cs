using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankApp.Identity.Infrastructure.Repositories;
using Newtonsoft.Json;

namespace BankApp.Identity.Infrastructure.Outbox;

public class MessageOutbox : IMessageOutbox
{
    private readonly IOutboxRepository _outboxRepository;

    public MessageOutbox(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public async Task SendAsync<T>(string topic, T message, Guid messageId) where T : class
    {
        var serializedMessage = JsonConvert.SerializeObject(message);
        await _outboxRepository.AddAsync(new OutboxMessage
        {
            MessageId = messageId,
            SerializedMessage = serializedMessage,
            MessageType = ((T)message)?.GetType().AssemblyQualifiedName,
            Topic = topic,
            SentAt = DateTime.UtcNow
        });
        await _outboxRepository.SaveChangesAsync();
    }


    public async Task<IReadOnlyList<OutboxMessage>> GetUnsentAsync()
    {
        return await _outboxRepository.GetUnsentAsync();
    }

    public async Task ProcessAsync(OutboxMessage message)
    {
        message.ProcessedAt = DateTime.UtcNow;
        _outboxRepository.Update(message);
        await _outboxRepository.SaveChangesAsync();
    }
}