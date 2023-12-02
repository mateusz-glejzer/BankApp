using System;
using System.Collections.Generic;
using BankApp.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Bootstrapper;

public static class ModulesExtensions
{
    private static Dictionary<string, IModule> RegisteredModules = new();

    public static void MapModulesEndpoints(IEndpointRouteBuilder endpointRouteBuilder)
    {
        foreach (var module in RegisteredModules.Values)
        {
            foreach (var endpoint in module.GetEndpoints())
            {
                var endpointRoute = module.Path + endpoint.Path;

                endpointRouteBuilder.MapMethods(
                    pattern: endpointRoute,
                    httpMethods: new[] { endpoint.HttpVerb.ToString().ToUpper() },
                    handler: endpoint.Handler);
            }
        }
    }

    public static void RegisterModule<TModule>(Func<TModule> moduleFactory = default) where TModule : IModule
    {
        var moduleDefinition = moduleFactory is not null
            ? moduleFactory()
            : Activator.CreateInstance<TModule>();

        RegisteredModules.Add(moduleDefinition.Name, moduleDefinition);
    }

    public static void AddModules(this IServiceCollection services, IConfiguration configuration)
    {
        foreach (var module in RegisteredModules.Values)
        {
            module.Register(services, configuration);
        }
    }
}