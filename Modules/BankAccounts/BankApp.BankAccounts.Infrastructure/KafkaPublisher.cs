using System;
using System.Threading.Tasks;
using BankApp.Wallets.Infrastructure.Outbox;
using Confluent.Kafka;

namespace BankApp.Wallets.Infrastructure;

public class KafkaPublisher : IBusPublisher
{
    private readonly IMessageOutbox _outbox;
    private readonly ProducerConfig _producerConfig;

    public KafkaPublisher(ProducerConfig producerConfig)
    {
        // _producerConfig = producerConfig;
        _producerConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };
    }


    public Task PublishAsync<T>(T message, Guid messageId) where T : class
    {
        throw new System.NotImplementedException();
    }
}