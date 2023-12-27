using BankApp.Identity.Core.Commands;
using BankApp.Identity.Core.Commands.CommandHandlers;
using BankApp.Identity.Core.Identity.Models;
using BankApp.Identity.Core.Identity.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Identity.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<ICommandHandler<SignUpCommand>, SignUpCommandHandler>();
        services.AddScoped<ICommandHandler<SignInCommand, AuthorizationDto>, SignInCommandHandler>();
        return services;
    }
}