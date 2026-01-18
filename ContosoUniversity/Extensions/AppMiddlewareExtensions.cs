using ContosoUniversity.Middlewares;

namespace ContosoUniversity.Extensions
{
    public static class AppMiddlewareExtensions
    {
        public static IApplicationBuilder UseVersionning(this IApplicationBuilder builder)
        {
            return builder.
            UseMiddleware<VersionHeaderMiddleware>();
        }
    }
}
