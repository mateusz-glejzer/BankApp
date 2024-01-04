using System.Threading.Tasks;

namespace BankApp.Identity.Infrastructure.Messages;

public interface IPublisher
{
    Task PublishAsync(string topic, string message);
}