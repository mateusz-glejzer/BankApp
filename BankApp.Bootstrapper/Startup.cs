using System.Collections.Generic;
using System.Reflection;
using BankApp.Shared.Abstractions.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankApp.Bootstrapper;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IList<Assembly> _assemblies;
    private readonly IList<IModule> _modules;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
        _assemblies = ModuleLoader.LoadAssemblies();
        _modules = ModuleLoader.LoadModules(_assemblies);
    }

    public void ConfigureServices(IServiceCollection services)
    {
        foreach (var module in _modules)
        {
            module.Register(services, _configuration);
        }
    }

    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            applicationBuilder.UseDeveloperExceptionPage();
        }

        applicationBuilder.UseRouting();
        applicationBuilder.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        
        _assemblies.Clear();
        _modules.Clear();
    }
}