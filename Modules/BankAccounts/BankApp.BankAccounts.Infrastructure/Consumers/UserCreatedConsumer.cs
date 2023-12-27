using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace BankApp.BankAccounts.Infrastructure.Consumers;

public class UserCreatedConsumer : BackgroundService
{
    private readonly IConsumer<Null, string> _consumer;

    public UserCreatedConsumer()
    {
        var dupa = new ConsumerConfig() { BootstrapServers = "localhost:29092", GroupId = "bank_accounts" };
        _consumer = new ConsumerBuilder<Null, string>(dupa).Build();
        _consumer.Subscribe("userCreated");
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var dupa = _consumer.Consume(stoppingToken);
            var message = dupa.Message;
        }

        _consumer.Close();
        return Task.CompletedTask;
    }
}