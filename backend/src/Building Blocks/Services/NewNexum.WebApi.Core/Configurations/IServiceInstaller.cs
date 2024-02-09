using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NewNexum.WebApi.Core.Configurations
{
    public interface IServiceInstaller
    {
        void Install(IServiceCollection services, IConfiguration configuration);
    }
}
