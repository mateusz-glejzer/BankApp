using System.Linq;
using System.Threading.Tasks;
using BankApp.BankAccounts.Infrastructure.MessageProducers;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace BankApp.BankAccounts.Infrastructure.Outbox;

public class OutboxProcessor : IJob
{
    private readonly IPublisher _publisher;
    private readonly IServiceScopeFactory _serviceScopeFactory;


    public OutboxProcessor(IPublisher publisher, IServiceScopeFactory serviceScopeFactory)
    {
        _publisher = publisher;
        _serviceScopeFactory = serviceScopeFactory;
    }

    private async Task SendOutboxMessagesAsync()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var outbox = scope.ServiceProvider.GetRequiredService<IMessageOutbox>();
        var messages = await outbox.GetUnsentAsync();
        foreach (var message in messages.OrderBy(outboxMessage => outboxMessage.SentAt))
        {
            await _publisher.PublishAsync(message.Topic, message.SerializedMessage);
            await outbox.ProcessAsync(message);
        }
    }

    public async Task Execute(IJobExecutionContext context)
    {
        await SendOutboxMessagesAsync();
    }
}