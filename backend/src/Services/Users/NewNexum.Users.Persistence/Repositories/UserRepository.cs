using NewNexum.Infra.Database;
using NewNexum.Users.Domain.User;

namespace NewNexum.Users.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
