using MiddlewareDemo.services;

namespace MiddlewareDemo.middlewares
{
    public class LoggerMiddleware
    {
        private RequestDelegate next;
        private ILogger<LoggerMiddleware> logger;
        private IDummyService dummyService;
        public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger, IDummyService dummyService)
        {            
            this.next = next;
            this.logger = logger;
            this.dummyService = dummyService;
            logger.LogInformation($"instance of {nameof(LoggerMiddleware)} created...");
        }

        //public async Task Invoke()
        public async Task InvokeAsync(HttpContext context)
        {
            logger.LogInformation($"Request came at {DateTime.Now} from {context.Request.Path}");
            logger.LogInformation(dummyService.DummyMethod());

            await next(context);

            logger.LogInformation($"Response returning at {DateTime.Now}");
        }
    }
}
