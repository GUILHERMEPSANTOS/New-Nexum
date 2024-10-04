using NewNexum.Core.Behaviors;
using NewNexum.WebApi.Core.Configurations;
using FluentValidation;
using NewNexum.Profile.Application.Authorization;
using NewNexum.WebApi.Core.Authorization;
using Microsoft.Extensions.Options;

namespace NewNexum.Profile.Api.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(ref IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<PermissionDelegatingHandler>();

            services.Configure<UserOptions>(configuration.GetSection("Users"));

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(Application.AssemblyReference.Assembly);
                config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            });

            services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);

            services.AddHttpClient<IPermissionService, PermissionService>((serviceProvider, httpClient) =>
            {
                var userUrl = serviceProvider
                      .GetRequiredService<IOptions<UserOptions>>().Value;

                httpClient.BaseAddress = new Uri(userUrl.Url);
            }).AddHttpMessageHandler<PermissionDelegatingHandler>();
        }
    }
}
