using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewNexum.Core.Communication
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None
                || !isSuccess && error == Error)
            {
                throw new ArgumentException("Invalid error.", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }
        public static Result Success() => new(true, Error.None);

        public static Result<TValue> Success<TValue>(TValue value) => new(value: value, isSuccess: true, error: Error.None);

        public static Result Failure(Error error) => new(false, error);

        public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

        public static Result<TValue> Create<TValue>(TValue value) => value is not null ? Success<TValue>(value) : Failure<TValue>(Error.NullValue);     
    }
}
