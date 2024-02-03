using Microsoft.EntityFrameworkCore;
using NewNexum.Core.DomainObjects;
using NewNexum.Core.ValueObjects;
using NewNexum.Infra.Database;
using NewNexum.Profile.Domain;

namespace NewNexum.Profile.Persistence
{
    public sealed class ApplicationDbContext : DbContext, IDbContext
    {
        public DbSet<Certification> Certifications { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }        

        public new DbSet<TEntity> Set<TEntity>()
            where TEntity : Entity
            => base.Set<TEntity>();

        public void Insert<TEntity>(TEntity entity)
            where TEntity : Entity
            => base.Set<TEntity>().Add(entity);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
