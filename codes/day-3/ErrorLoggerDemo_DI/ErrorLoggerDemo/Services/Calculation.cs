namespace ErrorLoggerDemo.Services
{
    public class Calculation(IErrorLogger logger) : ICalculation
    {
        private readonly IErrorLogger logger = logger;
        public int Add(int a, int b)
        {
            try
            {
                return a + b;
            }
            catch (Exception e)
            {
                logger.LogError(e);
                throw;
            }
        }

        public int Divide(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception e)
            {
                logger.LogError(e);
                throw;
            }
        }

        public int Multiply(int a, int b)
        {
            try
            {
                return a * b;
            }
            catch (Exception e)
            {
                logger.LogError(e);
                throw;
            }
        }

        public int Subtract(int a, int b)
        {
            try
            {
                return a - b;
            }
            catch (Exception e)
            {
                logger.LogError(e);
                throw;
            }
        }
    }
}
