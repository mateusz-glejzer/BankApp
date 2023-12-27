using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankApp.Identity.Infrastructure.Outbox;

public interface IMessageOutbox
{
    Task SendAsync<T>(string topic, T message, Guid messageId) where T : class;
    Task<IReadOnlyList<OutboxMessage>> GetUnsentAsync();
    Task ProcessAsync(OutboxMessage message);
}