using Microsoft.EntityFrameworkCore;
using NewNexum.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Infra.Database
{
    public abstract class GenericRepository<TAggregateRoot>
        where TAggregateRoot : AggregateRoot
    {
        private readonly IDbContext DbContext;

        protected GenericRepository(IDbContext dbContext) => DbContext = dbContext;

        public void Insert(TAggregateRoot entity) => DbContext.Insert(entity);
    }
}
