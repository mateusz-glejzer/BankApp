using System;
using System.Threading.Tasks;
using BankApp.Wallets.Core;
using BankApp.Wallets.Infrastructure.Outbox;

namespace BankApp.Wallets.Infrastructure;

public class MessageBroker : IMessageBroker
{
    private readonly IMessageOutbox _outbox;

    public MessageBroker(IMessageOutbox outbox)
    {
        _outbox = outbox;
    }

    public async Task PublishAsync<T>(T message) where T : class
    {
        if (message is null)
        {
            return;
        }

        await _outbox.SendAsync(message, Guid.NewGuid());
    }
}