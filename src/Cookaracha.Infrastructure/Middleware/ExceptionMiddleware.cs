using Cookaracha.Core.Exceptions;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Cookaracha.Infrastructure.Middleware;

internal sealed class ExceptionMiddleware : IMiddleware
{
    private const string ErrorMessageTemplate = "An exception has been thrown: {Message}";

    private record Error(string Code, string Message);

    private ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CustomException exception)
        {
            _logger.LogError(ErrorMessageTemplate, exception.Message);
            await HandleExceptionAsync(exception, exception.StatusCode, context);
        }
        catch (Exception exception)
        {
            _logger.LogError(ErrorMessageTemplate, exception.Message);
            await HandleExceptionAsync(exception, StatusCodes.Status500InternalServerError, context);
        }
    }

    private static async Task HandleExceptionAsync(Exception exception, int statusCode, HttpContext context)
    {
        var error = exception switch
        {
            CustomException => new Error(exception.GetType().Name.Underscore().Replace("_exception", string.Empty), exception.Message),
            _ => new Error("error", "An unexpected error occurred on the server.")
        };

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(error);
    }
}