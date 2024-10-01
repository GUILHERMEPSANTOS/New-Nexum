using NewNexum.Core.Messaging;
using NewNexum.WebApi.Core.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Users.Application.Users.Queries.GetUserPermissions
{
    internal class GetUserPermissionQuery : IQuery<PermissionsResponse>
    {
        public string IdentityId { get; set; }
    }
}
