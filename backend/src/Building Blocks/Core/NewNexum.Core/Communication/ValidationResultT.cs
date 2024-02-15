using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Core.Communication
{
    public class ValidationResult<TValue> : Result<TValue>, IValidationResult
    {
        public Error[] Errors { get; }

        private ValidationResult(Error[] errors) : base(default, false, IValidationResult.Error)
        {
            Errors = errors;
        }

        public static IValidationResult WithErrors(Error[] errors) => new ValidationResult<TValue>(errors);
    }
}
