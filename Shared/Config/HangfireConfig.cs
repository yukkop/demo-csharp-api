// using Hangfire;
// using Hangfire.Dashboard;
// using Hangfire.PostgreSql;
// using Logic.Logic.Interface;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
//
// namespace rest_vpn.Config;
//
// public static class HangfireConfig
// {
//
//     public static void RegisterHangfire(this IServiceCollection services, IConfiguration config)
//     {
//         // Hangfire configuration
//         services.AddHangfire(configuration => configuration
//        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
//        .UseSimpleAssemblyNameTypeSerializer()
//        .UseRecommendedSerializerSettings()
//        .UsePostgreSqlStorage(config.GetConnectionString("DefaultConnection"), new PostgreSqlStorageOptions
//        {
//            SchemaName = "hangfire"
//        }));
//
//         // Hangfire server
//         services.AddHangfireServer();
//         services.AddHangfireServer(jobsServerOptions =>
//         {
//             //
//             // Hangfire's default worker count is 20, which opens 20 connections simultaneously.
//             // For this we are overriding the default value.
//             //
//             jobsServerOptions.WorkerCount = 1;
//         });
//     }
//
//     public static void RegisterHangfire(this IApplicationBuilder app)
//     {
//         app.UseHangfireDashboard("/hangfire", new DashboardOptions
//         {
//             Authorization = new[] {
//                     new HangfireAuthorizationFilter()
//                 }
//         });
//
//         RecurringJob.AddOrUpdate<IVpnUserLogic>(x => x.DecreaseBalancesAndUpdateTime(), Cron.Hourly());
//     }
// }
//
// public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
// {
//     public bool Authorize(DashboardContext context)
//     {
//         return true;
//     }
// }