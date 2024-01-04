using System.Threading.Tasks;
using Confluent.Kafka;

namespace BankApp.Identity.Infrastructure.Messages;

public class KafkaPublisher : IPublisher
{
    private readonly IProducer<Null, string> _producer;

    public KafkaPublisher()
    {
        var producerConfig = new ProducerConfig { BootstrapServers = "localhost:29092" };

        _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }


    public async Task PublishAsync(string topic, string message)
    {
        await _producer.ProduceAsync(topic, new Message<Null, string>
        {
            Value = message,
        });
    }
}