using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ServiceScopeAndLifetime
{
    internal class Program
    {
        static void Main()
        {
            ServiceProvider provider = ConfigureServices();
            Console.WriteLine($"1st call to {nameof(CreateScopeAndInstances)} \n");
            CreateScopeAndInstances(provider);

            Console.WriteLine($"\n2nd call to {nameof(CreateScopeAndInstances)} \n");
            CreateScopeAndInstances(provider);
        }
        static void CreateScopeAndInstances(IServiceProvider provider)
        {
            using IServiceScope scope = provider.CreateScope();

            //a provider that will be used to resolve services within this scope (scoped provider)
            IServiceProvider localProvider = scope.ServiceProvider;

            Console.WriteLine("\n1st attempt within the scope to create a new instance of Banking operations\n");

            using (IOperations operations1 = localProvider.GetRequiredService<IOperations>())
            {
                Console.WriteLine(operations1.CreateAccount("joydip", "abcd1234"));
            }

            Console.WriteLine("\n2nd attempt within the scope to create a new instance of Banking operations\n");

            IOperations operations2 = localProvider.GetRequiredService<IOperations>();
            Console.WriteLine(operations2.CreateAccount("joydip", "abcd1234"));
        }
        static ServiceProvider ConfigureServices()
        {
            IServiceCollection containerBuilder = new ServiceCollection();
            //containerBuilder.AddTransient<IOperations, BankingOperations>();
            ServiceDescriptor boDescriptor = new
                (
                    serviceType: typeof(IOperations),
                    implementationType: typeof(BankingOperations),
                    lifetime: ServiceLifetime.Transient
                );
            containerBuilder.Add(boDescriptor);
            return containerBuilder.BuildServiceProvider();
        }
    }
}
