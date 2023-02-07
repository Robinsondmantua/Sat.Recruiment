using System.Text.Json;
using Sat.Recruiment.Application.Common.Exceptions;

namespace Sat.Recruiment.Api.Middelwares
{

    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = ex switch
                {
                    DuplicateDataException => StatusCodes.Status409Conflict,
                    ValidationException => StatusCodes.Status400BadRequest,
                    _ => StatusCodes.Status500InternalServerError
                };

                var result = JsonSerializer.Serialize(new { message = ex.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
