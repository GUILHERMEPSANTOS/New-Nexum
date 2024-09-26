using Microsoft.EntityFrameworkCore;
using NewNexum.Users.Persistence;
using System.Runtime.CompilerServices;

namespace NewNexum.Profile.Api.Configurations
{
    public static class MigrationConfiguration
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            ApplyMigration<ApplicationDbContext>(scope);
        }

        private  static void ApplyMigration<TDbContext>(this IServiceScope scope)
            where TDbContext : DbContext
        {
            using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

            context.Database.Migrate();
        }
    }
}
