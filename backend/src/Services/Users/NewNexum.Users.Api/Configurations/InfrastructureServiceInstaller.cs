using Microsoft.Extensions.Options;
using NewNexum.Infra.IdP;
using NewNexum.Infra.IdP.Keycloak;
using NewNexum.Users.Infrastructure.Identity;
using NewNexum.WebApi.Core.Configurations;
using Scrutor;

namespace NewNexum.Users.Api.Configurations
{
    public class InfrastructureServiceInstaller : IServiceInstaller
    {
        public void Install(ref IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KeyCloakOptions>(configuration.GetSection("KeyCloak"));

            services.AddTransient<KeyCloakAuthDelegatingHandler>();
            services.AddTransient<IIdentityProviderService, IdentityProviderKeycloakService>();

            services
                .AddHttpClient<KeyCloakClient>((serviceProvider, httpClient) =>
                {
                    KeyCloakOptions keyCloakOptions = serviceProvider
                        .GetRequiredService<IOptions<KeyCloakOptions>>().Value;

                    httpClient.BaseAddress = new Uri(keyCloakOptions.AdminUrl);
                })
                .AddHttpMessageHandler<KeyCloakAuthDelegatingHandler>();

            services.Scan(selector =>
               selector.FromAssemblies(Persistence.AssemblyReference.Assembly)
                       .AddClasses(false)
                       .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                       .AsMatchingInterface()
                       .WithScopedLifetime());
        }
    }
}
