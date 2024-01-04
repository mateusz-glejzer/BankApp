using System;
using System.Threading.Tasks;
using BankApp.Identity.Core;
using BankApp.Identity.Infrastructure.Outbox;

namespace BankApp.Identity.Infrastructure.Messages;

public class MessageBroker : IMessageBroker
{
    private readonly IMessageOutbox _outbox;

    public MessageBroker(IMessageOutbox outbox)
    {
        _outbox = outbox;
    }

    public async Task PublishAsync<T>(string topic, T message) where T : class
    {
        if (message is null)
        {
            return;
        }

        await _outbox.SendAsync(topic, message, Guid.NewGuid());
    }
}