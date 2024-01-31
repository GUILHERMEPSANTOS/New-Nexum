using NewNexum.Core.DomainObjects;

namespace NewNexum.Infra.Database
{
    public interface IDbContext
    {
        void Insert<TEntity>(TEntity entity)
               where TEntity : Entity;
    }
}
