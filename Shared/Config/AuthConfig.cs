using System.Text;
using Logic.Database;
using Logic.Database.Models;
using Logic.Enum;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Shared.Config;

public static class AuthConfig
{
    public static void RegisterAuth(this IServiceCollection services, IConfiguration config)
    {

        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<PgDbContext>()
            .AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = config["Jwt:Issuer"],
                ValidAudience = config["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
            };
        });
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy(PolicyEnum.CanPerformAdminOperations.ToString(), policy =>
                policy.RequireClaim(CustomClaimEnum.Permission.ToString(), PolicyEnum.CanPerformAdminOperations.ToString()));
            options.AddPolicy(PolicyEnum.CanPerformBotSystemOperations.ToString(), policy =>
                policy.RequireClaim(CustomClaimEnum.Permission.ToString(), PolicyEnum.CanPerformBotSystemOperations.ToString()));
        });

        services.AddAuthorization();
    }

    public static void RegisterAuth(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}