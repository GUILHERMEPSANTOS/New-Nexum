using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NewNexum.WebApi.Core.Authentication;

namespace NewNexum.WebApi.Core.Configurations
{
    public class JwtServiceInstaller : IServiceInstaller
    {
        public void Install(ref IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureOptions<JwtBearerConfigureOptions>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer();
            
            //options =>
            //{
            //    options.MetadataAddress = $"{configuration["Keycloak:server-url"]}/realms/new-nexum-realm/.well-known/openid-configuration";
            //    options.RequireHttpsMetadata = Convert.ToBoolean($"{configuration["Keycloak:require-https"]}");
            //    options.SaveToken = true;
            //
            //    options.  = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        ValidateAudience = true,
            //        ValidAudience = $"{configuration["Keycloak:audience"]}",
            //        ValidateIssuer = Convert.ToBoolean($"{configuration["Keycloak:validate-issuer"]}"),
            //        ValidateLifetime = true,
            //    };
            //});
        }
    }
}
