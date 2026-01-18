namespace ContosoUniversity.Middlewares
{
    public class VersionHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        public VersionHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration) {
            var version = configuration["Version:Supported"];
            context.Response.Headers["X-Service-Version"] = version;
            await _next(context);
        }
    }
}
