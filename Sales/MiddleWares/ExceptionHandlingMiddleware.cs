using Microsoft.AspNetCore.Http;
using Sales.Application;
using Sales.Application.Helpers;
using Sales.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sales.API.MiddleWares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
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

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            
            if(exception is EmployeeAlreadyExistsException ||
                exception is ManagerIdNotValidException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var reponse = ResponseHelper.Fail<AppResponse<EmptyResponse>>(Application.Enums.ResponseStatusCode.Error, exception.Message);
            await context.Response.WriteAsync(reponse.ToString());

        }
    }
}
