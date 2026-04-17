using Microsoft.EntityFrameworkCore;
using Siemns.DotNet.PmsApp.APIs.Mapper;
using Siemns.DotNet.PmsApp.APIs.Models.Dao.Abstractions;
using Siemns.DotNet.PmsApp.APIs.Models.Dao.Implementations;
using Siemns.DotNet.PmsApp.APIs.Models.DTOs;
using Siemns.DotNet.PmsApp.APIs.Models.Entities;
using Siemns.DotNet.PmsApp.APIs.Models.Repository;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Action<DbContextOptionsBuilder> contextAction = (optionsBuilder => optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("SiemensDbConStr")));

builder.Services.AddDbContext<SiemensDbContext>(contextAction, ServiceLifetime.Singleton);
builder.Services.AddAutoMapper(config => config.AddProfile<AppMapper>());
builder.Services.AddSingleton<IDbService<ProductDTO, int>, ProductDaoService>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
