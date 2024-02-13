using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NewNexum.Core.Communication;

namespace API.Extensions;

public static class ResultExtensions
{
    public static Result<TOut> Map<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> func)
        => result is not null && result.IsSuccess ? func(result.Value) : Result.Failure<TOut>(result.Error);

    public static async Task<Result<TOut>> Bind<TIn, TOut>(this Result<TIn> result, Func<TIn, Task<TOut>> func)
        => result is not null && result.IsSuccess ? await func(result.Value) : Result.Failure<TOut>(result.Error);

    public static async Task<Result> Bind<TIn>(this Result<TIn> result, Func<TIn, Task<Result>> func) =>
           result.IsSuccess ? await func(result.Value) : Result.Failure(result.Error);

    public static async Task<TOut> Match<TIn, TOut>(this Task<Result<TIn>> resultTask, Func<TIn, TOut> onSuccess, Func<Result<TIn>, TOut> onFailure)
    {
        var result = await resultTask;

        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
    }

    public static async Task<T> Match<T>(this Task<Result> resultTask, Func<T> onSuccess, Func<Result, T> onFailure)
    {
        Result result = await resultTask;

        return result.IsSuccess ? onSuccess() : onFailure(result);
    }

    public static ProblemDetails ToProblemDetails(this Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException("");
        }

        return new()
        {
            Title = GetTitle(result.Error.Type),
            Type = result.Error.Code,
            Detail = result.Error.Description,
            Status = GetStatusCode(result.Error.Type),
        };

        static int GetStatusCode(ErrorType type)
            => type switch
            {
                ErrorType.Failure => StatusCodes.Status400BadRequest,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError,
            };

        static string GetTitle(ErrorType type)
            => type switch
            {
                ErrorType.Failure => "Bad Request",
                ErrorType.NotFound => "Not Found",
                ErrorType.Conflict => "Conflict",
                ErrorType.Validation => "Validation",
                _ => "Internal Server Error",
            };
    }
}