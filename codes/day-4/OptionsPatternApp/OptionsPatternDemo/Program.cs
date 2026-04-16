using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OptionsPatternDemo.Models;
using OptionsPatternDemo.Repository;

namespace OptionsPatternDemo
{
    internal class Program
    {
        static void Main()
        {
            ConfigurationBuilder configuationBuilder = new();

            IConfigurationRoot configurationProvider =
                configuationBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            //FileSettingOptions? fileSettingOptions =
            //     configurationProvider
            //     .GetRequiredSection("FileSettingOptions")
            //     .Get<FileSettingOptions>();

            //Console.WriteLine(fileSettingOptions?.FilePath);

            IServiceCollection serviceProviderBuilder = new ServiceCollection();

            //ServiceProvider serviceProvider =
            //    serviceProviderBuilder
            //    .AddSingleton<IFileRepository, TextFileRepository>()
            //    .AddSingleton<FileSettingOptions>(fileSettingOptions)
            //    .BuildServiceProvider();

            //Action<FileSettingOptions> optionsAction = options =>
            //{
            //    options.FilePath = configurationProvider.GetRequiredSection("FileSettingOptions:FilePath")?.Value;
            //    options.Mode = configurationProvider.GetRequiredSection("FileSettingOptions:Mode")?.Value;
            //};
            //ServiceProvider serviceProvider =
            //    serviceProviderBuilder
            //    .Configure<FileSettingOptions>(optionsAction)
            //    .AddSingleton<IFileRepository, TextFileRepository>()
            //    .BuildServiceProvider();


            ServiceProvider serviceProvider =
                    serviceProviderBuilder
                     .Configure<FileSettingOptions>(configurationProvider.GetRequiredSection(nameof(FileSettingOptions)))
                     .AddSingleton<IFileRepository, TextFileRepository>()
                     .BuildServiceProvider();

            IFileRepository fileRepository = serviceProvider.GetRequiredService<IFileRepository>();
            Console.WriteLine(fileRepository.ReadData());

        }
    }
}
