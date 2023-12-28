using System;
using System.Threading.Tasks;

namespace BankApp.Identity.Infrastructure;

public interface IPublisher
{
    Task PublishAsync(string topic, string message);
}