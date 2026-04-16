using HostingDemo.Models;
using HostingDemo.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HostingDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = new HostApplicationBuilder(args);

            hostBuilder
                .Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            hostBuilder
                .Services
                .Configure<FileSettingOptions>(hostBuilder.Configuration.GetRequiredSection(nameof(FileSettingOptions)))
                .AddSingleton<IFileRepository, TextFileRepository>();

            hostBuilder
                .Logging
                .AddSimpleConsole();

            IHost host = hostBuilder.Build();

            using var scope = host.Services.CreateScope();
            var localProvider = scope.ServiceProvider;
            var fileRepository = localProvider.GetRequiredService<IFileRepository>();

           ILogger<Program> programLogger = localProvider.GetRequiredService<ILogger<Program>>();
            programLogger.LogInformation(fileRepository?.ReadData());

            await host.RunAsync();
        }
    }
}
