using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using BankApp.Identity.Core.Commands;
using BankApp.Identity.Core.Extensions;
using BankApp.Identity.Core.Identity.Models;
using BankApp.Identity.Infrastructure.Extensions;
using BankApp.Shared.Infrastructure.Configuration;
using BankApp.Shared.Infrastructure.Modules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BankApp.Identity.Api;

public class IdentityModule : IModule
{
    public string Name => "IdentityModule";
    public string Path => "identity";

    public IReadOnlyList<EndpointInfo> GetEndpoints()
    {
        return new[]
        {
            new EndpointInfo("/login", HttpMethod.Post,
                async ([FromBody] SignInCommand signInCommand, [FromServices] ICommandDispatcher commandDispatcher) =>
                await commandDispatcher.SendAsync<SignInCommand, AuthorizationDto>(signInCommand),
                AuthorizationLevel.Anonymous, false),
            new EndpointInfo("/register", HttpMethod.Post,
                async ([FromBody] SignUpCommand signUpCommand, [FromServices] ICommandDispatcher commandDispatcher) =>
                {
                    await commandDispatcher.SendAsync(signUpCommand);
                }, AuthorizationLevel.Anonymous, false),
            new EndpointInfo("/refresh-token/use", HttpMethod.Get,
                ([FromBody] UseRefreshTokenCommand useRefreshTokenCommand,
                        [FromServices] ICommandDispatcher commandDispatcher) =>
                    commandDispatcher.SendAsync(useRefreshTokenCommand), AuthorizationLevel.Client, false),
        };
    }

    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddCore();
        services.AddInfrastructure(configuration);
    }
}