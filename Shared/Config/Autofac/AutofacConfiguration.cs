using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Shared.Config.Autofac;

public static class AutofacConfiguration
{
    public static void RegisterAutofac(this WebApplicationBuilder builder)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        // Register services directly with Autofac here. Don't
        // call builder.Populate(), that happens in AutofacServiceProviderFactory.
        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            containerBuilder.RegisterModule(new AutofacModule()));
    }
}