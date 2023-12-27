using Confluent.Kafka;

namespace BankApp.Identity.Infrastructure;

public class KafkaMessageBrokerConfig
{
    public ProducerConfig ProducerConfig { get; set; }
}