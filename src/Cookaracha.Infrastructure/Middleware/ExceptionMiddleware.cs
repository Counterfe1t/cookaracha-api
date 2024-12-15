using Cookaracha.Core.Exceptions;
using Humanizer;
using Microsoft.AspNetCore.Http;

namespace Cookaracha.Infrastructure.Middleware;

internal sealed class ExceptionMiddleware : IMiddleware
{
    private record Error(string Code, string Message);

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            // TODO: Add proper error logging with serilog
            Console.WriteLine(exception.Message);
            await HandleExceptionAsync(exception, context);
        }
    }

    private async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        var (statusCode, error) = exception switch
        {
            CustomException => (
                StatusCodes.Status400BadRequest,
                new Error(exception.GetType().Name.Underscore().Replace("_exception", string.Empty), exception.Message)),
            _ => (StatusCodes.Status500InternalServerError, new Error("error", "An unexpected error occurred on the server."))
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(error);
    }
}