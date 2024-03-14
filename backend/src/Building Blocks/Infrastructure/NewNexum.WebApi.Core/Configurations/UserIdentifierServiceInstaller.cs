using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewNexum.Core.User;
using NewNexum.WebApi.Core.Authentication.Claims;
using NewNexum.WebApi.Core.User;

namespace NewNexum.WebApi.Core.Configurations
{
    public class UserIdentifierServiceInstaller : IServiceInstaller
    {
        public void Install(ref IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserIdentifierProvider, UserIdentifierProvider>();
            services.AddTransient<IClaimsTransformation>(_ => new KeycloakRolesClaimsTransformation(configuration["Keycloak:audience"] ?? ""));
        }
    }
}
