﻿using Newtonsoft.Json;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace GymManager.UI.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware>logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "GymManager Request: Nieobsłużony wyjątek - Request {Name}", context.Request.Path);

            await HandleExceptionAsync(context, exception).ConfigureAwait(false);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        int statusCode = (int)HttpStatusCode.InternalServerError;
        var result = JsonConvert.SerializeObject(new
        {
            StatusCode = statusCode,
            ErrorMessage = exception.Message,
        });
        context.Response.Redirect($"{context.Request.Scheme}://{context.Request.Host}/Error");
        return context.Response.WriteAsync(result);
    }

       

}
