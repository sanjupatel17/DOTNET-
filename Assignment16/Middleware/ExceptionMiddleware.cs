using System.Net;
using System.Text.Json;

namespace Assignment16.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next,
                                   IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode =
                    (int)HttpStatusCode.InternalServerError;

                var message = _env.IsDevelopment()
                    ? ex.Message
                    : "Internal Server Error";

                var result = JsonSerializer.Serialize(new
                {
                    error = message
                });

                await context.Response.WriteAsync(result);
            }
        }
    }
}