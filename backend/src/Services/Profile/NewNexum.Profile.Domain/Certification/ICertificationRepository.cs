using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Profile.Domain
{
    public interface ICertificationRepository
    {
        void Insert(Certification certification);
    }
}
