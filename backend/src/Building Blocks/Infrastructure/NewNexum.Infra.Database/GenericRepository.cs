using NewNexum.Core.DomainObjects;

namespace NewNexum.Infra.Database
{
    public abstract class GenericRepository<TAggregateRoot>
        where TAggregateRoot : AggregateRoot
    {
        protected readonly IDbContext DbContext;

        protected GenericRepository(IDbContext dbContext) => DbContext = dbContext;

        public void Insert(TAggregateRoot entity) => DbContext.Insert(entity);
    }
}
