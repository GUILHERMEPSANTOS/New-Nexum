using Scrutor;
using NewNexum.WebApi.Core.Configurations;

namespace NewNexum.Profile.Api.Configurations
{
    public class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(ref IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(selector =>
               selector.FromAssemblies(Persistence.AssemblyReference.Assembly)
                       .AddClasses(false)
                       .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                       .AsMatchingInterface()
                       .WithScopedLifetime());
        }
    }
}
