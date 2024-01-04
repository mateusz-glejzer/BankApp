using Confluent.Kafka;

namespace BankApp.BankAccounts.Infrastructure.MessageProducers;

public class KafkaMessageBrokerConfig
{
    public ProducerConfig ProducerConfig { get; set; }
}