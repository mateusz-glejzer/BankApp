using Confluent.Kafka;

namespace BankApp.Identity.Infrastructure.Messages;

public class KafkaMessageBrokerConfig
{
    public ProducerConfig ProducerConfig { get; set; }
}