using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BankApp.Shared.Abstractions.Modules;

namespace BankApp.Bootstrapper;

internal class ModuleLoader
{
    public static IList<Assembly> LoadAssemblies()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var locations = assemblies.Where(assembly => !assembly.IsDynamic).Select(assembly => assembly.Location)
            .ToArray();
        var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
            .Where(file => !locations.Contains(file, StringComparer.InvariantCultureIgnoreCase))
            .ToList();

        files.ForEach(file => assemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(file))));

        return assemblies;
    }

    public static IList<IModule> LoadModules(IEnumerable<Assembly> assemblies)
        => assemblies
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => typeof(IModule).IsAssignableFrom(type) && !type.IsInterface)
            .OrderBy(type => type.Name)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();
}