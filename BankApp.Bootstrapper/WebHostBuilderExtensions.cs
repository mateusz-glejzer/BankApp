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
        public static IWebHostBuilder ConfigureModules(this IWebHostBuilder builder) =>
            builder.ConfigureAppConfiguration(
                (ctx, cfg) =>
                {
                    AddGlobalModulesSettings(cfg);
                    OverrideEnvironmentModulesSettings(ctx, cfg);
                });

        private static void OverrideEnvironmentModulesSettings(WebHostBuilderContext webHostBuilderContext,
            IConfigurationBuilder configurationBuilder)
        {
            foreach (var setting in GetSettings($"*.{webHostBuilderContext.HostingEnvironment.EnvironmentName}"))
            {
                configurationBuilder.AddJsonFile(setting);
            }
        }

        private static void AddGlobalModulesSettings(IConfigurationBuilder configurationBuilder)
        {
            foreach (var setting in GetSettings("*"))
            {
                if (setting.Split(Path.DirectorySeparatorChar).Last().Split(".").Length == 3)
                {
                    configurationBuilder.AddJsonFile(setting);
                }
            }
        }

        private static IEnumerable<string> GetSettings(string pattern) =>
            Directory.EnumerateFiles(
                AppDomain.CurrentDomain.BaseDirectory,
                $"module.{pattern}.json",
                SearchOption.AllDirectories);
    }
}