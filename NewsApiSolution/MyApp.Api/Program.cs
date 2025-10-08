using Microsoft.EntityFrameworkCore;
using MyApp.Application.Interfaces;
using MyApp.Infrastructure.Persistence;
using MediatR;
using MyApp.Application;

// Thêm các namespace cần thiết
using MyApp.Application.Interfaces.Repositories;
using MyApp.Application.Services;
using MyApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------
//  Controllers
// ------------------------------
builder.Services.AddControllers();

// ------------------------------
//  Database Configuration
// ------------------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Map interface DbContext (cho CQRS)
builder.Services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

// ------------------------------
//  Repository + Service Dependency Injection
// ------------------------------
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<INewsService, NewsService>();

builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IMenuService, MenuService>();

// ------------------------------
//  MediatR (Command/Query Handlers)
// ------------------------------
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(SomeAppMarker).Assembly));

// ------------------------------
//  Swagger (for API testing)
// ------------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ------------------------------
//  Build & Run
// ------------------------------
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
