namespace TaskNTeamManganementSystem.MiddleWares
{
    public class ErrorHandlingMiddlewareCustom
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddlewareCustom> _logger;

        public ErrorHandlingMiddlewareCustom(RequestDelegate next, ILogger<ErrorHandlingMiddlewareCustom> logger)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new
                {
                    Message = "Something went wrong"
                });
            }
        }
    }

}
