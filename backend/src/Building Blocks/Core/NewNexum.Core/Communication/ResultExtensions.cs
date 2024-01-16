using Microsoft.AspNetCore.Http;
using NewNexum.Core.Communication;

namespace API.Extensions;

public static class ResultExtensions
{

    public static IResult ToProblemDetails(this Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException("");
        }


        return Results.Problem(
           statusCode: GetStatusCode(result.Error.Type),
           title: GetTitle(result.Error.Type),
           type: "",
           extensions: new Dictionary<string, object?>
           {
               { "errors", new[] { result.Error } }
           }
        );

        static int GetStatusCode(ErrorType type)
            => type switch
            {
                ErrorType.Failure => StatusCodes.Status400BadRequest,
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
                _ => "Internal Server Error",
            };
    }
}