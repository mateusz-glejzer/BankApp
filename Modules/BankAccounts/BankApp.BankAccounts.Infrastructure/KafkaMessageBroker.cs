using System.Collections.Generic;
using System.Threading.Tasks;
using BankApp.Wallets.Core;
using BankApp.Wallets.Core.Events;
using Confluent.Kafka;

namespace BankApp.Wallets.Infrastructure;

public class KafkaMessageBroker : IMessageBroker
{
    private readonly ProducerConfig _producerConfig;

    public KafkaMessageBroker(ProducerConfig producerConfig)
    {
        // _producerConfig = producerConfig;
        _producerConfig = new ProducerConfig { BootstrapServers = "localhost:9092" };
    }

    public Task PublishAsync(IEnumerable<IEvent> events)
    {
        throw new System.NotImplementedException();
    }
}