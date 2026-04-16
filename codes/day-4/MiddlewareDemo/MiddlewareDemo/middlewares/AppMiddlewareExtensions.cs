using MiddlewareDemo.services;

namespace MiddlewareDemo.middlewares
{
    public static class AppMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggerMiddlware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<LoggerMiddleware>();
            return builder;
        }

        public static IServiceCollection AddLoggerMiddleware(this IServiceCollection builder)
        {
            builder.AddTransient<IDummyService, DummyService>();
            return builder;
        }
    }
}
