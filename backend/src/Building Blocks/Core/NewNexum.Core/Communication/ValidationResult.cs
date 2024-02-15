using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewNexum.Core.Communication
{
    public sealed class ValidationResult : Result, IValidationResult
    {
        public Error[] Errors { get; }

        private ValidationResult(Error[] errors) : base(false, IValidationResult.Error)
        {
            Errors = errors;
        }

        public static ValidationResult WithErrors(Error[] errors) => new(errors);
    }
}
