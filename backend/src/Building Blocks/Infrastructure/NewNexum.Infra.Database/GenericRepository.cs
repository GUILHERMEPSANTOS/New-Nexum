using Microsoft.EntityFrameworkCore;
using NewNexum.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Infra.Database
{
    public abstract class GenericRepository<TEntity>
        where TEntity : Entity
    {
        private readonly IDbContext DbContext;

        protected GenericRepository(IDbContext dbContext) => DbContext = dbContext;

        public void Insert(TEntity entity) => DbContext.Insert(entity);
    }
}
