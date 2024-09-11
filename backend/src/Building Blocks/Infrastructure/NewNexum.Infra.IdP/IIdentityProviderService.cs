using NewNexum.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Infra.IdP
{
    public interface IIdentityProviderService
    {
        Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);
    }
}
