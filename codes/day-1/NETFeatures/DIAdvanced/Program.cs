using Microsoft.Extensions.DependencyInjection;

namespace DIAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider provider = ConfigureServices();
            IMessenger messenger = provider.GetRequiredKeyedService<IMessenger>("simple");
            Console.WriteLine(messenger.Greet("joydip"));

            IRepository<Customer> customerRepo = provider.GetRequiredService<IRepository<Customer>>();
            var all = customerRepo.GetAll();
            foreach (var item in all)
            {
                Console.WriteLine($"Name={item.Name}");
            }
        }
        static IServiceProvider ConfigureServices()
        {
            IServiceCollection builder = new ServiceCollection();
            builder.AddKeyedSingleton<IMessenger, SimpleMessenger>("simple");
            builder.AddKeyedSingleton<IMessenger, AdvanedMessenger>("advanced");

            builder.AddSingleton<IRepository<Customer>, CustomerRepository>();
            builder.AddSingleton<IRepository<Order>, OrderRepository>();
            return builder.BuildServiceProvider();
        }
    }
}
