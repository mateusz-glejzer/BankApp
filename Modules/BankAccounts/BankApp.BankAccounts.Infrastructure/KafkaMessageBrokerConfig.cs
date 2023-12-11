using Confluent.Kafka;

namespace BankApp.BankAccounts.Infrastructure;

public class KafkaMessageBrokerConfig
{
    public ProducerConfig ProducerConfig { get; set; }
}