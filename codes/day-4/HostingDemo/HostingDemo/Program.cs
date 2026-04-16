using HostingDemo.Models;
using HostingDemo.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


//namespace HostingDemo
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {

//Main method executable code -> Top level statements [one file -> route file -> the file with Main method].
//no need to write the boiler plate code - namespace, class and Main method declaration

HostApplicationBuilder hostBuilder = ConfigureHostBuilder(args);
IHost host = hostBuilder.Build();

using IServiceScope scope = UseRepository(host);
await host.RunAsync();

static HostApplicationBuilder ConfigureHostBuilder(string[] args)
{
    //static void Foo() { }
    //Foo();
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

    return hostBuilder;
}

static IServiceScope UseRepository(IHost host)
{
    var scope = host.Services.CreateScope();
    var localProvider = scope.ServiceProvider;
    var fileRepository = localProvider.GetRequiredService<IFileRepository>();

    ILogger<Program> programLogger = localProvider.GetRequiredService<ILogger<Program>>();
    programLogger.LogInformation(fileRepository?.ReadData());
    return scope;
}
//        }
//    }
//}