﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VA.Infrastructure.CrossCutting.Shared;

namespace VA.Infrastructure.CrossCutting.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await OnExceptionAsync(ex, httpContext);
            }
        }

        private async Task OnExceptionAsync(Exception exception, HttpContext httpContext)
        {
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError(exception, "{Method} {Request} {Message}", httpContext.Request.Method, httpContext.Request.Path.Value, exception.Message);
            }

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isEnvironmentDevelop = environment == "Development" || environment == "QA";

            var statusCode = GetStatusCode(exception);

            var message = (isEnvironmentDevelop || statusCode is (int)HttpStatusCode.BadRequest)
                ? exception.Message
                : ResponseConstants.ErrorMessageWhenOccurExceptionInRequest;

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";

            var problemDetails = new ProblemDetails { Title = message, Status = statusCode, Type = exception?.GetType()?.ToString() };
            problemDetails.Extensions["traceId"] = httpContext?.TraceIdentifier;

            var response = new Response(problemDetails, false);
            response.AddErrorMessage(message);

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response), Encoding.UTF8);
        }

        private static int GetStatusCode(Exception ex)
        {
            return ex switch
            {
                ArgumentException _ => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
