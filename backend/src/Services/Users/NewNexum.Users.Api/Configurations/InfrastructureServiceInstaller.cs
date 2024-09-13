using NewNexum.Infra.IdP;
using NewNexum.WebApi.Core.Configurations;
using Scrutor;

namespace NewNexum.Users.Api.Configurations
{
    public class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(ref IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IIdentityProviderService, IdentityProviderKeyCloakService>


            services.Scan(selector =>
               selector.FromAssemblies(Persistence.AssemblyReference.Assembly)
                       .AddClasses(false)
                       .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                       .AsMatchingInterface()
                       .WithScopedLifetime());
        }
    }
}
