using MiddlewareDemo.middlewares;

WebApplicationBuilder webHostbuilder = CreateAndConfigureWebHostBuilder(args);

WebApplication webHost = webHostbuilder.Build();

ConfigureMiddlewarePipeline(webHost);

webHost.Run();

static WebApplicationBuilder CreateAndConfigureWebHostBuilder(string[] args)
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
    //builder.WebHost.UseServer()
    //builder.Services.AddTransient<IDummyService, DummyService>();
    builder.Services.AddLoggerMiddleware();
    builder.Services.AddControllers();
    //builder.Services.AddAuthorization(); <-- AddControllers() automatically registers the required services for Authorization middleware
    return builder;
}

static void ConfigureMiddlewarePipeline(WebApplication webHost)
{
    //the Invoke/InvokeAsync method is called at this point, but the instance of loggermiddleware was created much earlier at the time when WebApplicarion object (host) was created
    webHost.UseLoggerMiddlware();
    webHost.UseAuthorization();
    webHost.MapControllers();
    //app.MapGet("/", () => "Hello World!");
    //Func<HttpContext, RequestDelegate, Task> func = async (context, next) => { };
    //app.Use(func)
}