using FinApp.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace FinApp.Presentation.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occured.");

            var code = HttpStatusCode.InternalServerError;

            if(ex is DomainException)
            {
                code = HttpStatusCode.BadRequest;
            }

            if (ex is UserNotFoundException)
            {
                code = HttpStatusCode.NotFound;
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)code;

            var errorResponse = new
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = ex is DomainException || ex is UserNotFoundException ? ex.Message : "An unexpected error occurred. Please try again later."
            };

            return httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
