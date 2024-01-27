using System.Threading.Tasks;

namespace BankApp.BankAccounts.Core;

public interface IMessageBroker
{
    Task PublishAsync<T>(string topic, T message) where T : class;
}