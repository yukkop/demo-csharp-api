using Logic;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Config;

public static class AutoMapperConfig
{
    public static void RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile));
    }
}