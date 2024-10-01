using Dapper;
using Microsoft.EntityFrameworkCore;
using NewNexum.Infra.Database;
using NewNexum.Users.Domain.User;
using System.Data;

namespace NewNexum.Users.Persistence.Repositories
{
    public class UserRepository(IDbContext dbContext) : GenericRepository<User>(dbContext), IUserRepository
    {
        public async Task<IEnumerable<UserPermission>> GetUserPermission(string IdentityId)
        {
            using var connection = DbContext.GetContext().Database.GetDbConnection();

            DynamicParameters parameters = new();
            parameters.Add("@IdentityId", IdentityId);

            return await connection.QueryAsync<UserPermission>(
                sql: @"SELECT UserId	 = USERS.Id
                       	     ,Permission = ROLE_PERMISSIONS.PermissionCode
                       FROM USERS.USERS WITH (NOLOCK)
                         INNER JOIN Users.user_roles WITH (NOLOCK)
                         ON USERS.Id = user_roles.UserId
                         INNER JOIN USERS.ROLE_PERMISSIONS WITH (NOLOCK)
                         ON ROLE_PERMISSIONS.RoleName = user_roles.role_name
                       WHERE USERS.IdentityId = @IdentityId",
                param: parameters,
                commandType: CommandType.Text
            );
        }

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
