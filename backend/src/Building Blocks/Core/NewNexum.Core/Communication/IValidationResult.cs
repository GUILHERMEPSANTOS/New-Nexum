using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Core.Communication
{
    public interface IValidationResult
    {
        Error[] Errors { get; }

        public static readonly Error Error = new("ValidationError", "A validation problem occured.", ErrorType.Validation);
    }
}
