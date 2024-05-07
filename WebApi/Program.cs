using Logic.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shared.Config;
using Shared.Config.Autofac;
using WebApi.Middleware;
using Swashbuckle.AspNetCore.SwaggerUI;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// устаревшее поведение Даты и Времени в postgreSQL
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // устаревшее поведение Даты и Времени в postgreSQL

// Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<PgDbContext>(options =>
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("WebApi")));

// Loggining
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
builder.Services.AddLogging();
var path = builder.Configuration.GetValue("LoggingPath", Path.Combine(Directory.GetCurrentDirectory(), "logs"));
Console.Write($"Logging Path: {path}\n");
builder.Logging.AddFile(Path.Combine(path, "log.txt"));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add and configure Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Configure Swagger to use JWT authentication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter JWT with Bearer prefix into the field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.RegisterAutoMapper();

builder.Services.AddHttpContextAccessor();

builder.Services.AddHealthChecks();

// builder.Services.RegisterHangfire(builder.Configuration);

// Add Auth
builder.Services.RegisterAuth(builder.Configuration);

// Add Autofac
builder.RegisterAutofac();

// CORS
builder.Services.AddCors();

HangfireConfig.Register(builder.Services, builder.Configuration);

var app = builder.Build();

app.RegisterAuth();

// TODO tmp
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
    }
    else
    {
        await next.Invoke();
    }
});

app.UseMiddleware(typeof(BadRequestMiddleware));

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.DocumentTitle = "My API";
    c.DocExpansion(DocExpansion.None);

    // Enable the "Authorize" button in Swagger UI
    c.ConfigObject.AdditionalItems["oauth2RedirectUrl"] = "/swagger/oauth2-redirect.html";
});

// CORS
app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// app.UseHttpsRedirection();

app.UseAuthorization();

// app.RegisterHangfire();

app.MapControllers();

HangfireConfig.RegisterApp(app, builder.Environment);

app.Run();