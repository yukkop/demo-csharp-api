using Logic.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Config;

public class DbConfig
{
    public static void Regiser(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContextPool<PgDbContext>(options =>
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Cinema"))
        );
    }

    public static void InitializeDatabase(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
            scope.ServiceProvider.GetRequiredService<PgDbContext>().Database.Migrate();
        }
    }
}