using System.Collections.Generic;
using BankApp.Shared.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Shared.Infrastructure.Modules;

public interface IModule
{
    string Name { get; }
    string Path { get; }
    void Register(IServiceCollection services, IConfiguration configuration);
    IReadOnlyList<EndpointInfo> GetEndpoints();
}