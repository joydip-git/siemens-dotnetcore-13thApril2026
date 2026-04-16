namespace ErrorLoggerDemo.Services
{
    //dependency injection IErrorLogger type service
    public class Calculation : ICalculation
    {
        public int Add(int a, int b)
        {
            try
            {
                return a + b;
            }
            catch (Exception)
            {
                //log exception before throwing
                throw;
            }
        }

        public int Divide(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception)
            {
                //log exception before throwing
                throw;
            }
        }

        public int Multiply(int a, int b)
        {
            try
            {
                return a * b;
            }
            catch (Exception)
            {
                //log exception before throwing
                throw;
            }
        }

        public int Subtract(int a, int b)
        {
            try
            {
                return a - b;
            }
            catch (Exception)
            {
                //log exception before throwing
                throw;
            }
        }
    }
}
