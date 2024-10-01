using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Users.Domain.User
{
    public interface IUserRepository
    {
        void Insert(User user);
        Task<IEnumerable<UserPermission>> GetUserPermission(string IdentityId);
    }
}
