using BankApp.BankAccounts.Api;
using BankApp.Transactions.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankApp.Bootstrapper;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
    {
        ModulesExtensions.RegisterModule<BankAccountsModule>();
        ModulesExtensions.RegisterModule<TransactionsModule>();
        services.AddModules(_configuration);
    }

    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            applicationBuilder.UseDeveloperExceptionPage();
        }

        applicationBuilder.UseRouting();
        applicationBuilder.UseEndpoints(ModulesExtensions.MapModulesEndpoints);
    }
}