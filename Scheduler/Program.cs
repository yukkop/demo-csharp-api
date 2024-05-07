using Microsoft.EntityFrameworkCore;
using Logic.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Config;
using Shared.Config.Autofac;
using Sheduler.Config;

var builder = WebApplication.CreateBuilder(args);

// устаревшее поведение Даты и Времени в postgreSQL
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Add configuration files
// builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

Console.WriteLine(connectionString);
builder.Services.AddDbContextPool<PgDbContext>(options =>
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("WebApi")));

builder.Services.RegisterAutoMapper();

builder.Services.RegisterAuth(builder.Configuration);

// Add Autofac
builder.RegisterAutofac();

HangfireConfig.Register(builder.Services, builder.Configuration);

var app = builder.Build();

// Program logic
Console.WriteLine("Start");

// Example of using services
// Use the service in your application
// var universalPicturesOperationsReportsRepository =
//    app.Services.GetRequiredService<IUniversalPicturesOperationsReportsRepository>();

// var standaloneCollectingLogic = app.Services.GetRequiredService<IStandaloneCollectingLogic>();

app.MapGet("/", () => $"hello");

HangfireConfig.RegisterApp(app, builder.Environment);

app.Run();