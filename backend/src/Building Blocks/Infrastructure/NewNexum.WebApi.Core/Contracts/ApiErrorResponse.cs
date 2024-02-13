using NewNexum.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.WebApi.Core.Contracts
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(IReadOnlyCollection<Error> errors) => Errors = errors;

        public IReadOnlyCollection<Error> Errors { get; }
    }
}
