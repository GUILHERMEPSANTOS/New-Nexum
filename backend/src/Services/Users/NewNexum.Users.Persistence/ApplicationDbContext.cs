using Microsoft.EntityFrameworkCore;
using NewNexum.Core.DomainObjects;
using NewNexum.Infra.Database;

namespace NewNexum.Users.Persistence
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public new DbSet<TEntity> Set<TEntity>()
            where TEntity : Entity
            => base.Set<TEntity>();

        public void Insert<TEntity>(TEntity entity) 
            where TEntity : Entity
            => Set<TEntity>().Add(entity);
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
