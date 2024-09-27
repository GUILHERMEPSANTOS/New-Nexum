using System.Runtime.ConstrainedExecution;
using Microsoft.EntityFrameworkCore;
using NewNexum.Core.DomainObjects;

namespace NewNexum.Infra.Database
{
    public interface IDbContext
    { 
        void Insert<TEntity>(TEntity entity)
               where TEntity : Entity;

        DbContext GetContext();
    }
}
