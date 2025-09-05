using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaVentas.App.Exceptions;
using System.Net;
using System.Text.Json;

namespace SistemaVentas.Api.Middleware
{
    public class DatabaseExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AppExceptionHandlerMiddleware> _logger;
        private static readonly Dictionary<Type, HttpStatusCode> StatusCodes = new()
        {
            { typeof(ConcurrencyException), HttpStatusCode.InternalServerError },
        };

        public DatabaseExceptionMiddleware(RequestDelegate next, ILogger<AppExceptionHandlerMiddleware> logger)
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
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx)
            {
                _logger.LogError(ex, "Database Error: {Message}", ex.Message);
                object response;
                string result;
                if (sqlEx.Number == 547)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";

                    response = new
                    {
                        error = "Violación de clave foránea. Verifique los datos enviados."
                    };

                    result = JsonSerializer.Serialize(response);
                    await context.Response.WriteAsync(result);
                }
                else
                {
                    response = new
                    {
                        message = ex.Message
                    };

                    result = JsonSerializer.Serialize(response);
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = GetStatusCodeForException(ex);
                    await context.Response.WriteAsync(result);
                }
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
