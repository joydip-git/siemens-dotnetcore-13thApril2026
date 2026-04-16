using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SampleCoreWebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder webHostBuilder = WebApplication.CreateBuilder(args);

            WebApplication webHost = webHostBuilder.Build();

            var logger = webHost.Services.GetRequiredService<ILogger<Program>>();

            Delegate endpoint = () => "hello";

            //webHost.UseAuthorization();
            Func<HttpContext, RequestDelegate, Task> func = async (HttpContext context, RequestDelegate next) =>
            {
                HttpRequest request = context.Request;
                string path = request.Path;
                HttpResponse response = context.Response;

                logger.LogInformation($"in Use: request came from {path} at {DateTime.Now}");

                await next(context);

                logger.LogInformation($"in Use: response going at {DateTime.Now}");
            };
            webHost.Use(func);

            Action<IApplicationBuilder> action = (IApplicationBuilder appBuilder) =>
            {
                appBuilder.Use(async (contxt, next) =>
                {
                    logger.LogInformation("in Map and in Use");
                    await next(contxt);
                });
                appBuilder.Run(async (context) =>
                {
                    logger.LogInformation("in Map and in Run");
                });
            };
            webHost.Map("/admin", action);
            //webHost.Map("/welcome", () => "Welcome...");
            //webHost.Run(async (context) => 
            //{
            //    logger.LogInformation($"in Run: request came from {context.Request.Path} at {DateTime.Now}");
            //});

            await webHost.RunAsync();
        }
    }
}
