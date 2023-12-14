using System.Collections.Generic;
using System.Net.Http;
using BankApp.Identity.Core.Commands;
using BankApp.Identity.Core.Extensions;
using BankApp.Identity.Infrastructure.Extensions;
using BankApp.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Identity.Api;

public class IdentityModule : IModule
{
    public string Name => "IdentityModule";
    public string Path => "identity";

    public IReadOnlyList<EndpointInfo> GetEndpoints()
    {
        return new[]
        {
            new EndpointInfo("/login", HttpMethod.Get,
                async ([FromBody] SignInCommand signInCommand, [FromServices] ICommandDispatcher commandDispatcher) =>
                await commandDispatcher.SendAsync(signInCommand)),
            new EndpointInfo("/register", HttpMethod.Post,
                async ([FromBody] SignUpCommand signUpCommand, [FromServices] ICommandDispatcher commandDispatcher) =>
                {
                    await commandDispatcher.SendAsync(signUpCommand);
                }),
            new EndpointInfo("/refresh-token/use", HttpMethod.Get,
                ([FromBody] UseRefreshTokenCommand useRefreshTokenCommand,
                        [FromServices] ICommandDispatcher commandDispatcher) =>
                    commandDispatcher.SendAsync(useRefreshTokenCommand)),
        };
    }

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCore(configuration);
        services.AddInfrastructure(configuration);
    }
}