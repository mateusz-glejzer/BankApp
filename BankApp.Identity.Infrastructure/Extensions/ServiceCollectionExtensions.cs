using BankApp.Identity.Core;
using BankApp.Identity.Core.Identity;
using BankApp.Identity.Core.Identity.Services;
using BankApp.Identity.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BankApp.Identity.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, JwtOptions jwtOptions)
    {
        //TODO add DBContext

        services.AddSingleton(jwtOptions);
        services.AddDbContext<IdentityDbContext>(optionsBuilder =>
            optionsBuilder.UseNpgsql(
                "Host=localhost; Database=bankApp-modular; Username=postgres;"));
        services.AddScoped<ISaltRepository, SaltRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddScoped<IJwtTokenHandler, JwtTokenHandler>();
        return services;
    }
}