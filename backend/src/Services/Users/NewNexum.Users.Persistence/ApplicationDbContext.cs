using Microsoft.EntityFrameworkCore;
using NewNexum.Core.DomainObjects;
using NewNexum.Infra.Database;
using NewNexum.Users.Domain.User;
using NewNexum.Users.Persistence.Configurations;
using NewNexum.Users.Persistence.Users.Configurations;

namespace NewNexum.Users.Persistence
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        internal DbSet<User> Users { get; set; }
            
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public new DbSet<TEntity> Set<TEntity>()
            where TEntity : Entity
            => base.Set<TEntity>();

        public void Insert<TEntity>(TEntity entity)
            where TEntity : Entity
            => Set<TEntity>().Add(entity);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schemas.Users);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
        }
    }
}
