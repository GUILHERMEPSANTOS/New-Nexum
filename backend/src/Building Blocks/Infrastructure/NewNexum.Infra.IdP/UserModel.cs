using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Infra.IdP
{
    public record UserModel(string Email, string Password, string FirstName, string LastName);
}
