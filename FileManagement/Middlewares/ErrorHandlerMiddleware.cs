using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FileManagement.Common.Exceptions;
using FileManagement.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FileManagement.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;

        public ErrorHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string message = exception.Message;
            IList<string> errorDetails = null;

            if (exception is HttpException ex)
            {
                statusCode = ex.StatusCode;
                message = ex.Message;
                errorDetails = ex.ErrorDetails;
            }

            var logger = _loggerFactory.CreateLogger<ErrorHandlerMiddleware>();
            logger.LogError(exception, exception.Message);

            var response = context.Response;
            response.Clear();
            response.ContentType = "application/json";
            response.StatusCode = statusCode;

            var apiResponse = new ApiResponse()
            {
                Success = false,
                StatusCode = statusCode,
                Data = new ApiError()
                {
                    Message = message,
                    Errors = errorDetails
                }
            };

            var content = JsonConvert.SerializeObject(apiResponse,
                new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                });

            await response.WriteAsync(content);
        }
    }

    public static class ErrorHandlerMiddlewareExtensions
    {
        public static void UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware(typeof(ErrorHandlerMiddleware));
        }
    }
}
