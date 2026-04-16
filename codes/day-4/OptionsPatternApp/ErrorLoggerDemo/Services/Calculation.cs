namespace ErrorLoggerDemo.Services
{
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
                throw;
            }
        }
    }
}
