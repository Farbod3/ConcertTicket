using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Common.Dependency;
using Data.Repository.GenericRepository;
using Data.Repository.IGenericRepository;
using Entities;
using Service.JWT;

namespace WebFramework.FarbodAutoFac;

public class FarbodAutoFac : Module, IModule
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        var commonAssembly = typeof(IScopedDependency).Assembly;
        var entityAssembly = typeof(IBaseEntity).Assembly;
        var dataAssembly = typeof(IRepository<>).Assembly;
        var serviceAssembly = typeof(JwtManager).Assembly;
        builder.RegisterGeneric(typeof(Repository<>))
            .As(typeof(IRepository<>))
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(commonAssembly, entityAssembly, dataAssembly, serviceAssembly)
            .AssignableTo<IScopedDependency>()
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(commonAssembly, entityAssembly, dataAssembly, serviceAssembly)
            .AssignableTo<ITransientDependency>()
            .AsImplementedInterfaces()
            .InstancePerDependency();

        builder.RegisterAssemblyTypes(commonAssembly, entityAssembly, dataAssembly, serviceAssembly)
            .AssignableTo<ISingletonDependency>()
            .AsImplementedInterfaces()
            .SingleInstance();
    }

    public new void Configure(IComponentRegistryBuilder componentRegistry)
    {
        base.Configure(componentRegistry);
    }
}