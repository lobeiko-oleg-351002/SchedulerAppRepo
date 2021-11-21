using BLL.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SchedulerViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SchedulerApp.Middleware
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

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(UserValidationException ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode httpStatus)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatus;
            await context.Response.WriteAsync(new ErrorModel()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }.ToString());
        }
    }
}
