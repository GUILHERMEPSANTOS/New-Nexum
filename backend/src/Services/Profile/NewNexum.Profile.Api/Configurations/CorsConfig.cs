using System;

namespace NewNexum.Profile.Api.Configurations
{
    public static class CorsConfig
    {
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
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

            return services;
        }

        public static WebApplication UseCorsConfiguration(this WebApplication app)
        {
            app.UseCors("All");

            return app;
        }
    }
}
