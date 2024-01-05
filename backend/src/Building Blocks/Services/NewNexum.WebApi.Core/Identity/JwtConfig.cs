using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace NewNexum.WebApi.Core.Identity
{
    public static class JwtConfig
    {
        public static IServiceCollection AddAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.MetadataAddress = $"{configuration["Keycloak:server-url"]}/realms/new-nexum-realm/.well-known/openid-configuration";
                 options.RequireHttpsMetadata = Convert.ToBoolean($"{configuration["Keycloak:require-https"]}");
                 options.SaveToken = true;

                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     //ValidateAudience = true,
                     ValidateIssuer = Convert.ToBoolean($"{configuration["Keycloak:validate-issuer"]}"),                     
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                 };
             });

            return services;
        }

        public static WebApplication UseAuthConfiguration(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}
