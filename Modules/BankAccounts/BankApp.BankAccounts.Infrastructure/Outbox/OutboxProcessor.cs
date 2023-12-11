using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankApp.BankAccounts.Infrastructure.Outbox;

public class OutboxProcessor : IHostedService
{
    private readonly IBusPublisher _publisher;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public OutboxProcessor(IBusPublisher publisher, IServiceScopeFactory serviceScopeFactory)
    {
        _publisher = publisher;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await SendOutboxMessagesAsync();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private async Task SendOutboxMessagesAsync()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var outbox = scope.ServiceProvider.GetRequiredService<IMessageOutbox>();
        var messages = await outbox.GetUnsentAsync();
        foreach (var message in messages.OrderBy(outboxMessage => outboxMessage.SentAt))
        {
            await _publisher.PublishAsync(message.SerializedMessage, message.MessageId);
            await outbox.ProcessAsync(message);
        }
    }
}