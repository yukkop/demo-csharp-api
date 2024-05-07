using System.Reflection;
using Autofac;
using Logic.Repositories;
using Module = Autofac.Module;

namespace Shared.Config.Autofac;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        var assembly = Assembly.Load(new AssemblyName("logic"));

        builder.RegisterGeneric(typeof(Repository<>))
            .As(typeof(IRepository<>))
            .InstancePerDependency();

        builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.Name.EndsWith("Logic"))
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(assembly)
            .Where(t => t.Name.EndsWith("Repository"));
    }
}