using Microsoft.EntityFrameworkCore;
using NewNexum.Core.DomainObjects;
using NewNexum.Infra.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Profile.Persistence
{
    public sealed class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public void Insert<TEntity>(TEntity entity)
            where TEntity : Entity
            => base.Set<TEntity>().Add(entity);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
        }
    }
}
