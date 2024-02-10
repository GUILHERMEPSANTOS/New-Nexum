using NewNexum.WebApi.Core.Configurations;

namespace NewNexum.Profile.Api.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(ref IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(Application.AssemblyReference.Assembly);
            });
        }
    }
}
