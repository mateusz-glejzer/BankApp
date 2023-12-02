using Confluent.Kafka;

namespace BankApp.Wallets.Infrastructure;

public class KafkaMessageBrokerConfig
{
    public ProducerConfig ProducerConfig { get; set; }
}