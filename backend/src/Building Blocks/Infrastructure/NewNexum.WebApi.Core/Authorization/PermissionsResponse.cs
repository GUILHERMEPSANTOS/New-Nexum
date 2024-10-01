using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.WebApi.Core.Authorization
{
    internal record PermissionsResponse(Guid userId, HashSet<string> Permissions);
}
