using System.Threading.Tasks;
using BankApp.Shared.Infrastructure.Modules;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace BankApp.Bootstrapper;

public class Program
{
    public static async Task Main(string[] args) => await CreateWebHostBuilder(args).Build().RunAsync();

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureModules().UseStartup<Startup>();
}