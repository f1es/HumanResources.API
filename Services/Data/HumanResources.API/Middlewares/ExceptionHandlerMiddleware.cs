using HumanResources.Core.Exceptions;
using System.Net;
using System.Reflection.Metadata;
using System.Text.Json;

namespace HumanResources.API.Middlewares;

public class ExceptionHandlerMiddleware
{
	private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(ex, context);
        }
    }

    private async Task HandleException(Exception ex, HttpContext context)
    {
        var statusCode = GetStatusCode(ex);
        var message = ex.Message;
        var stackTrace = ex.StackTrace;

        var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace});

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        await context.Response.WriteAsync(exceptionResult);
    }

    private HttpStatusCode GetStatusCode(Exception ex) =>
        ex switch
        {
            NotFoundException => HttpStatusCode.NotFound,
            _ => HttpStatusCode.InternalServerError,
        };
}
