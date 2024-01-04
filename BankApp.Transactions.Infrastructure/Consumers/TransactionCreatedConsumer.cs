using System.Threading;
using System.Threading.Tasks;
using BankApp.Transactions.Core.Commands.Dispatcher;
using BankApp.Transactions.Core.Events;
using BankApp.Transactions.Core.Events.Dispatcher;
using BankApp.Transactions.Core.Shared;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace BankApp.Transactions.Infrastructure.Consumers;

public class TransactionCreatedConsumer : BackgroundService
{
    private readonly IConsumer<Null, string> _consumer;
    private readonly IEventDispatcher _eventDispatcher;

    public TransactionCreatedConsumer(IEventDispatcher eventDispatcher)
    {
        _eventDispatcher = eventDispatcher;
        var config = new ConsumerConfig() { BootstrapServers = "localhost:29092", GroupId = "transaction_service" };
        _consumer = new ConsumerBuilder<Null, string>(config).Build();
        _consumer.Subscribe("transaction-created");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var result = await Task.Run(() => _consumer.Consume(stoppingToken), stoppingToken);
            var message = result.Message;
            var transactionCreatedEvent = JsonConvert.DeserializeObject<TransactionCreatedEvent>(message.Value);
            await _eventDispatcher.DispatchAsync(transactionCreatedEvent, stoppingToken);
        }

        _consumer.Close();
    }
}