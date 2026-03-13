using System;
using Autofac;

namespace Starwars.Jedis.Business;

public sealed class BusinessAutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(JediBusiness).Assembly)
            .Where(type => type.Name.EndsWith("Business", StringComparison.Ordinal))
            .AsImplementedInterfaces()
            .InstancePerDependency();

        builder.RegisterType<JediFactory>()
            .InstancePerDependency();
    }
}
