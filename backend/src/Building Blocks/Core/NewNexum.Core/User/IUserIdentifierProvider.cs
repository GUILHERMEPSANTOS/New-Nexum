using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Core.User
{
    public interface IUserIdentifierProvider
    {
        string GetUserIdentifier();
    }
}
