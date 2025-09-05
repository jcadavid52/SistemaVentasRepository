using Azure.Core;
using SistemaVentas.App.Exceptions;
using SistemaVentas.Domain.Exceptions;
using System.Net;

namespace SistemaVentas.Api.Middleware
{
    public class AppExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AppExceptionHandlerMiddleware> _logger;
        private static readonly Dictionary<Type, HttpStatusCode> StatusCodes = new()
        {
            { typeof(ArgumentNullException), HttpStatusCode.BadRequest },
            { typeof(ArgumentOutOfRangeException), HttpStatusCode.BadRequest },
            { typeof(ArgumentException), HttpStatusCode.BadRequest },
            { typeof(NotFoundException), HttpStatusCode.NotFound },
            { typeof(NotFoundClientException), HttpStatusCode.NotFound },
            { typeof(ExistenceEmailException), HttpStatusCode.Conflict },
            { typeof(BusinessException), HttpStatusCode.BadRequest }
        };

        public AppExceptionHandlerMiddleware(RequestDelegate next, ILogger<AppExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: {Message}", ex.Message);
                object response;

                response = new
                {
                    message = ex.Message
                };

                var result = System.Text.Json.JsonSerializer.Serialize(response);
                context.Response.ContentType = ContentType.ApplicationJson.ToString();
                context.Response.StatusCode = GetStatusCodeForException(ex);
                await context.Response.WriteAsync(result);
            }

        }

        private static int GetStatusCodeForException(Exception ex)
        {
            return StatusCodes.TryGetValue(ex.GetType(), out var statusCode)
                ? (int)statusCode
                : (int)HttpStatusCode.InternalServerError;
        }
    }
}
