using System;
using System.Threading.Tasks;
using BankApp.BankAccounts.Infrastructure.Outbox;
using Confluent.Kafka;

namespace BankApp.BankAccounts.Infrastructure;

public class KafkaPublisher : IBusPublisher
{
    private readonly IMessageOutbox _outbox;
    private readonly ProducerConfig _producerConfig;

    public KafkaPublisher()
    {
        // _producerConfig = producerConfig;
        _producerConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };
    }


    public Task PublishAsync<T>(T message, Guid messageId) where T : class
    {
        using (var p = new ProducerBuilder<Null, string>(_producerConfig).Build())
        {
        }

        return Task.CompletedTask;
    }
}