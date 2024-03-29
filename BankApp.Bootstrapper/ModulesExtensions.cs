﻿using System;
using System.Collections.Generic;
using BankApp.Shared.Infrastructure.Configuration;
using BankApp.Shared.Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Bootstrapper;

public static class ModulesExtensions
{
    private static Dictionary<string, IModule> RegisteredModules = new();
    private static Dictionary<RouteInfo, AuthorizationLevel> RouteAccessAuthorizationLevels = new();

    public static void MapModulesEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        foreach (var module in RegisteredModules.Values)
        {
            foreach (var endpoint in module.GetEndpoints())
            {
                var endpointRoute = module.Path + endpoint.Path;

                RouteAccessAuthorizationLevels.Add(
                    new RouteInfo(endpointRoute, endpoint.HttpVerb.ToString()), endpoint.Role);
                if (endpoint.Authorize)
                {
                    endpointRouteBuilder.MapMethods(
                        pattern: endpointRoute,
                        httpMethods: new[] { endpoint.HttpVerb.ToString().ToUpper() },
                        handler: endpoint.Handler).RequireAuthorization();
                    continue;
                }

                endpointRouteBuilder.MapMethods(
                    pattern: endpointRoute,
                    httpMethods: new[] { endpoint.HttpVerb.ToString().ToUpper() },
                    handler: endpoint.Handler);
            }
        }
    }

    public static void RegisterModule<TModule>() where TModule : IModule
    {
        var moduleDefinition = Activator.CreateInstance<TModule>();

        RegisteredModules.Add(moduleDefinition.Name, moduleDefinition);
    }

    public static void AddModules(this IServiceCollection services, IConfiguration configuration)
    {
        foreach (var module in RegisteredModules.Values)
        {
            module.Register(services, configuration);
        }
    }

    public static AuthorizationLevel GetAccessLevel(RouteInfo route)
    {
        return RouteAccessAuthorizationLevels[route];
    }
}