
using BookstoreApplication.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;

namespace BookstoreApplication.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = e switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                ForbiddenException => StatusCodes.Status403Forbidden,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            var response = new { error = e.Message };
            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
