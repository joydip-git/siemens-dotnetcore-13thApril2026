namespace MiddlewareDemo.services
{
    public class DummyService : IDummyService
    {
        private readonly ILogger<DummyService> logger;
        public DummyService(ILogger<DummyService> logger)
        {
            this.logger = logger;
            logger.LogInformation($"instance of {nameof(DummyService)} created");
        }

        public string DummyMethod()
        {
            return "dummy method called";
        }
    }
}
