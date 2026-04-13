using DIService;
using Microsoft.Extensions.DependencyInjection;

namespace NETFeatures_DI
{
    interface ICalculation
    {
        int Add(int x, int y);
    }
    class Calculation : ICalculation
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
    }
    internal class Program
    {
        static void Main()
        {
            //var container = DIContainer.Create();
            //container
            //    .Register<IOperations, BankingOperations>();

            //IOperations operations = container.GetService<IOperations>();

            //creating instance of a builder where servivces can be registered
            IServiceCollection containerBuilder = new ServiceCollection();
            containerBuilder
                .Add(
                    new ServiceDescriptor
                    (
                        serviceType: typeof(IOperations),
                        implementationType: typeof(BankingOperations),
                        lifetime: ServiceLifetime.Singleton
                    )
                );
            containerBuilder
                .AddSingleton<ICalculation, Calculation>();
                //.AddScoped;
                //.AddTransient()

            //creating the container with the help of the builder
            IServiceProvider container = containerBuilder.BuildServiceProvider();

            //asking for DI of IOperations type service
            IOperations operations = container.GetRequiredService<IOperations>();

            int accNo = operations.CreateAccount("joydip", "abcd1234");
            Console.WriteLine(accNo);
            double balance = operations.Credit(accNo, 2000);
            Console.WriteLine(balance);

            ICalculation calculation = container.GetRequiredService<ICalculation>();
            Console.WriteLine(calculation.Add(12,14));
        }
    }
}
