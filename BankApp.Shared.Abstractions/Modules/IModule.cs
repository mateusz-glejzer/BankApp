using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Shared.Abstractions.Modules;

public interface IModule
{
    string Name { get; }
    string Path { get; }
    IEnumerable<string> Policies => null;
    void Register(IServiceCollection services, IConfiguration configuration);
    IReadOnlyList<EndpointInfo> GetEndpoints();
}