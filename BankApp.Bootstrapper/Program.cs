using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace BankApp.Bootstrapper;

public class Program
{
    public static void Main(string[] args)
    {
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}