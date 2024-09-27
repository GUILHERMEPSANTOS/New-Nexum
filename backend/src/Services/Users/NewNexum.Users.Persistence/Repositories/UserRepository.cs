using NewNexum.Infra.Database;
using NewNexum.Users.Domain.User;

namespace NewNexum.Users.Persistence.Repositories
{
    public class UserRepository(IDbContext dbContext) : GenericRepository<User>(dbContext), IUserRepository
    {
        public new void Insert(User user)
        {
            var context = DbContext.GetContext();

            foreach (var role in user.Roles)
            {
                context.Attach(role);
            }

            base.Insert(user);
        }
    }
}
