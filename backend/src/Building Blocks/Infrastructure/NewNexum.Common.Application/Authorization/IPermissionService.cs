using NewNexum.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.WebApi.Core.Authorization
{
    public interface IPermissionService
    {
        Task<Result<PermissionsResponse>> GetUserPermissionsAsync(string identityId);
    }
}
