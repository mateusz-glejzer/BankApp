using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BankApp.Bootstrapper
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder AddModuleConfiguration(this IWebHostBuilder builder) =>
            builder.ConfigureAppConfiguration(
                (ctx, cfg) =>
                {
                    foreach (var setting in GetConfiguration("*"))
                    {
                        if (setting.Split(Path.DirectorySeparatorChar).Last().Split(".").Length == 3)
                        {
                            cfg.AddJsonFile(setting);
                        }
                    }

                    foreach (var setting in
                             GetConfiguration($"*.{ctx.HostingEnvironment.EnvironmentName}"))
                    {
                        cfg.AddJsonFile(setting);
                    }
                });


        private static IEnumerable<string> GetConfiguration(string pattern) =>
            Directory.EnumerateFiles(
                AppDomain.CurrentDomain.BaseDirectory,
                $"module.{pattern}.json",
                SearchOption.AllDirectories);
    }
}