using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace BankApp.Identity.Infrastructure;

public class KafkaPublisher : IPublisher
{
    private readonly IProducer<Null, string> _producer;

    public KafkaPublisher()
    {
        var producerConfig = new ProducerConfig { BootstrapServers = "localhost:29092" };

        _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }


    public async Task PublishAsync<T>(string topic, T message, Guid messageId) where T : class
    {
        await _producer.ProduceAsync(topic, new Message<Null, string>
        {
            Value = JsonConvert.SerializeObject(message),
        });
    }
}