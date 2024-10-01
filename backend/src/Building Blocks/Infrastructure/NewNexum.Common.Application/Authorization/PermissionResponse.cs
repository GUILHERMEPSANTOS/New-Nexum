using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.WebApi.Core.Authorization;

public sealed record PermissionsResponse(Guid UserId, HashSet<string> Permissions);