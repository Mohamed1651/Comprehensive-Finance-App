﻿namespace FinApp.Presentation.Middleware
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
