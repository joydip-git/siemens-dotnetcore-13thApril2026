using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace SampleCoreWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder webHostBuilder = WebApplication.CreateBuilder(args);

            WebApplication webHost = webHostBuilder.Build();
            Delegate endpoint = () => "hello";

            webHost.UseAuthorization();

            webHost.Map("/welcome", endpoint);

            await webHost.RunAsync();
        }
    }
}
