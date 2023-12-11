using BankApp.BankAccounts.Api;
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
        // ModulesExtensions.RegisterModule<TransactionsModule>();
        // ModulesExtensions.RegisterModule<IdentityModule>();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddModules(_configuration);
    }

    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI();
            applicationBuilder.UseDeveloperExceptionPage();
        }

        applicationBuilder.UseRouting();
        applicationBuilder.UseEndpoints(endpointRouteBuilder =>
        {
            endpointRouteBuilder.MapModulesEndpoints();
            endpointRouteBuilder.MapControllers();
        });
    }
}