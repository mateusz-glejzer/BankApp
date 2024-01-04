using System.Threading.Tasks;

namespace BankApp.BankAccounts.Infrastructure.MessageProducers;

public interface IPublisher
{
    Task PublishAsync(string topic, string message);
}