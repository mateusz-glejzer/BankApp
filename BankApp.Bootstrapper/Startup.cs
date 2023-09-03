using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankApp.Bootstrapper;

public class Startup
{
    public void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers();
    }

    public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            applicationBuilder.UseDeveloperExceptionPage();
        }

        applicationBuilder.UseRouting();
        applicationBuilder.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}