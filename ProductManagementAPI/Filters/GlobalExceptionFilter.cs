using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Global Exception Triggered");

            if (context.Exception is ProductNotFoundException)
            {
                context.Result = new NotFoundObjectResult(context.Exception.Message);
            }
            else
            {
                context.Result = new ObjectResult("Internal Server Error")
                {
                    StatusCode = 500
                };
            }
        }
    }
}
