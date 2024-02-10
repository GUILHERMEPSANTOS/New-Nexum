using NewNexum.WebApi.Core.Configurations;
using System;

namespace NewNexum.Profile.Api.Configurations
{
    public class CorsServiceInstaller : IServiceInstaller
    {   
        public void Install(ref IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("All", configurePolicy =>
                {
                    configurePolicy
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowAnyHeader();
                });
            });
        }
    }
}
