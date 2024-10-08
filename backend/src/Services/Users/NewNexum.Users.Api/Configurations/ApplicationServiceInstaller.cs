using FluentValidation;
using NewNexum.Core.Behaviors;
using NewNexum.Users.Application.Authorization;
using NewNexum.WebApi.Core.Authorization;
using NewNexum.WebApi.Core.Configurations;

namespace NewNexum.Users.Api.Configurations
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
            services.AddScoped<IPermissionService, PermissionService>();
        }
    }
}
