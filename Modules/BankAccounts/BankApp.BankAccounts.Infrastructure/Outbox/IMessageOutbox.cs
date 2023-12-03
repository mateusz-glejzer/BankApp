using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankApp.Wallets.Infrastructure.Outbox;

public interface IMessageOutbox
{
    Task SendAsync<T>(T message, Guid messageId) where T : class;
    Task<IReadOnlyList<OutboxMessage>> GetUnsentAsync();
    Task ProcessAsync(OutboxMessage message);
}