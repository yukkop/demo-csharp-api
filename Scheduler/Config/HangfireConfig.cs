using Hangfire;
using Hangfire.Dashboard;
using Hangfire.PostgreSql;
using Logic.Logic.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sheduler.Config;

public class HangfireConfig
{
    public static void Register(IServiceCollection services, IConfiguration config)
    {
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UsePostgreSqlStorage(config.GetConnectionString("DefaultConnection"), new PostgreSqlStorageOptions
            {
                SchemaName = "hangfire"
            }));

        services.AddHangfireServer(jobsServerOptions =>
        {
            //
            // Hangfire's default worker count is 20, which opens 20 connections simultaneously.
            // For this we are overriding the default value.
            //
            jobsServerOptions.WorkerCount = 3;
        });
    }

    public static void RegisterApp(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseHangfireDashboard("/hangfire", new DashboardOptions
        {
            Authorization = new[]
            {
                new HangfireAuthorizationFilter()
            }
        });
        HangfireScheduling.StartSchedulingJobs(env);
    }
}

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        return true;
    }
}

public static class HangfireScheduling
{
    internal static void StartSchedulingJobs(IWebHostEnvironment env)
    {
        RecurringJob.AddOrUpdate<IVpnUserLogic>(job => job.DecreaseBalancesAndUpdateTime(), Cron.Hourly());
    }
}