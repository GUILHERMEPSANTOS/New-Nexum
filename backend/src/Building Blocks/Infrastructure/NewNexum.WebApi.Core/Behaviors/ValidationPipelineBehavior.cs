using FluentValidation;
using MediatR;
using NewNexum.Core.Communication;
using System.Reflection;


namespace NewNexum.Core.Behaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
         where TResponse : Result
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            Error[] errors = _validators.Select(validator => validator.Validate(request))
                   .SelectMany(result => result.Errors)
                   .Where(validationFailure => validationFailure is not null)
                   .Select(validationFailure => new Error(validationFailure.ErrorCode, validationFailure.ErrorMessage, ErrorType.Validation))
                   .Distinct()
                   .ToArray();

            if (errors.Any())
            {
                return CreateValidationResult<TResponse>(errors);
            }

            return await next();
        }

        private static TResult CreateValidationResult<TResult>(Error[] errors)
             where TResult : Result
        {
            if (typeof(Result) == typeof(TResult))
            {
                return (ValidationResult.WithErrors(errors) as TResult)!;
            }

            object validationResult = typeof(ValidationResult<>)
                .MakeGenericType(typeof(TResult).GenericTypeArguments[0])
                .GetMethod(nameof(ValidationResult.WithErrors))!
                .Invoke(null, new[] { errors })!;

            return (TResult)validationResult;
        }
    }
}