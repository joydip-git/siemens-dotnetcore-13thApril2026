using MiddlewareDemo.middlewares;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<IDummyService, DummyService>();
builder.Services.AddLoggerMiddleware();
builder.Services.AddControllers();
//builder.Services.AddAuthorization(); <-- AddControllers() automatically registers the required services for Authorization middleware

WebApplication app = builder.Build();

//the Invoke/InvokeAsync method is called at this point, but the instance of loggermiddleware was created much earlier at the time when WebApplicarion object (host) was created
app.UseLoggerMiddlware();
app.UseAuthorization();
app.MapControllers();
//app.MapGet("/", () => "Hello World!");
//Func<HttpContext, RequestDelegate, Task> func = async (context, next) => { };
//app.Use(func)
app.Run();
