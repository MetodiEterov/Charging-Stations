namespace ASP.NETTask.WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;

    using Entities.Contracts;
    using Entities.Helpers;

    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// ErrorHandlerMiddleware class
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        /// <summary>
        /// ErrorHandlerMiddleware constructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ErrorHandlerMiddleware(RequestDelegate next
            , ILoggerManager logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invoke method
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = error switch
                {
                    AppException _ => (int)HttpStatusCode.BadRequest,// custom application error
                    KeyNotFoundException _ => (int)HttpStatusCode.NotFound,// not found error
                    _ => (int)HttpStatusCode.InternalServerError,// unhandled error
                };

                _logger.LogError(error.Message);
                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
