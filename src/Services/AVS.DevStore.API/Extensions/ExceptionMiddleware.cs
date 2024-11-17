using Elmah.Io.AspNetCore;
using System.Net;

namespace AVS.DevStore.API.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
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
                HandleExceptionAsync(httpContext, ex);                
            }
        }

        private void HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            ex.Ship(httpContext);
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
