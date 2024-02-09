using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace NewNexum.WebApi.Core.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection InstallServices(this IServiceCollection services
              , IConfiguration configuration
              , Assembly[] assemblies)
        {
            var serviceInstallers = assemblies.SelectMany(a => a.DefinedTypes)
                   .Where(IsAssignableToType<IServiceInstaller>)
                   .Select(Activator.CreateInstance)
                   .Cast<IServiceInstaller>();

            foreach (var serviceInstaller in serviceInstallers)
            {
                serviceInstaller.Install(services, configuration);
            }

            return services;
        }

        private static bool IsAssignableToType<T>(TypeInfo typeInfo)
        {
            return typeof(T).IsAssignableFrom(typeInfo) &&
              !typeInfo.IsInterface &&
              !typeInfo.IsAbstract;
        }

    }
}
