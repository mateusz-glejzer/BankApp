using BankApp.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.BankAccounts.Api;

public class BankAccountsModule: IModule
{
    public string Name => "BankAccounts";
    public string Path => "bank-accounts-module";
    public void Register(IServiceCollection services)
    {
        throw new System.NotImplementedException();
    }

    public void Use(IApplicationBuilder app)
    {
        throw new System.NotImplementedException();
    }
}