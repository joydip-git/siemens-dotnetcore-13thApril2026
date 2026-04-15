using ErrorLoggerDemo.Models;
using ErrorLoggerDemo.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorLoggerDemo
{
    internal class Program
    {
        static void Main()
        {
            ServiceProvider? provider = null;
            IConfigurationRoot? configProvider = null;
            try
            {
                provider = CreateConfiguredServiceProvider();
                configProvider = CreateConfigurationProvider();

                using IServiceScope scope = provider.CreateScope();
                var scopedProvider = scope.ServiceProvider;
                var calculation = provider.GetRequiredService<ICalculation>();
                var res = calculation.Divide(12, 0);
                Console.WriteLine(res);
            }
            catch (Exception e)
            {
                //FileSetting? fileSetting = configProvider?.GetRequiredSection("FileSetting").Get<FileSetting>();
                //if (fileSetting != null && !string.IsNullOrEmpty(fileSetting.Path))
                //{
                //    try
                //    {
                //        var logger = provider?.GetRequiredService<IErrorLogger>();
                //        logger?.LogError(e);
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex);
                //    }
                //}
                //else
                Console.WriteLine(e);
            }
        }
        static ServiceProvider CreateConfiguredServiceProvider()
        {
            IServiceCollection serviceProviderBuilder = new ServiceCollection();
            serviceProviderBuilder
                .AddScoped<ICalculation, Calculation>()
                .AddScoped<IErrorLogger, ErrorLogger>();

            ServiceProvider provider = serviceProviderBuilder.BuildServiceProvider();
            return provider;
        }
        static IConfigurationRoot CreateConfigurationProvider()
        {
            var builder = new ConfigurationBuilder();
            var configProvider = builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
            return configProvider;
        }
    }
}
