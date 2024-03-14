using NewNexum.Core.Behaviors;
using NewNexum.WebApi.Core.Configurations;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace NewNexum.Profile.Api.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(ref IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(Application.AssemblyReference.Assembly);
                config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            });

            services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);
        }
    }
}
