using Microsoft.EntityFrameworkCore;
using NewNexum.Infra.Database;
using NewNexum.Users.Persistence;
using NewNexum.WebApi.Core.Configurations;

namespace NewNexum.Users.Api.Configurations
{
    public class PersistenceServiceInstaller : IServiceInstaller
    {
        public void Install(ref IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbContext>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());

            services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(configuration["ConnectionStrings:ProfileDB"])
            );
        }
    }
}
