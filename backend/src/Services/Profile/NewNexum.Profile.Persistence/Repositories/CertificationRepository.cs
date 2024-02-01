using NewNexum.Infra.Database;
using NewNexum.Profile.Domain;

namespace NewNexum.Profile.Persistence.Repositories
{
    public class CertificationRepository : GenericRepository<Certification>, ICertificationRepository
    {
        public CertificationRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
