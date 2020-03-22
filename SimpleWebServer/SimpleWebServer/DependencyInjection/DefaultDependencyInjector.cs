using System;
using Autofac;

namespace SimpleWebServer.DependencyInjection
{
    public class DefaultDependencyInjector : IDependencyInjector
    {
        private readonly ContainerBuilder _containerBuilder;
        private IContainer _container;
        private IContainer Container
        {
            get
            {
                if(_container == null)
                {
                    _container = _containerBuilder.Build();
                }

                return _container;
            }
        }

        public DefaultDependencyInjector()
        {
            _containerBuilder = new ContainerBuilder();
        }

        public void Register<TType, TImplementation>() where TImplementation : TType
        {

            _containerBuilder.RegisterType<TImplementation>().As<TType>();
        }

        public void Register(Type type, Type implementation)
        {
            _containerBuilder.RegisterType(type).As(implementation);
        }

        public void RegisterScoped<TType, TImplementation>() where TImplementation : TType
        {
            _containerBuilder.RegisterType<TImplementation>()
                .As<TType>()
                .InstancePerLifetimeScope();
        }

        public void RegisterScoped(Type type, Type implementation)
        {
            _containerBuilder.RegisterType(implementation)
                .As(type)
                .InstancePerLifetimeScope();
        }

        public void RegisterSingleton<TType, TImplementation>() where TImplementation : TType
        {
            _containerBuilder.RegisterType<TImplementation>()
                .As<TType>()
                .SingleInstance();
        }

        public void RegisterSingleton(Type type, Type implementation)
        {
            _containerBuilder.RegisterType(implementation)
                .As(type)
                .SingleInstance();
        }

        public IDependencyInjectionScope GetScope()
        {
            var lifetimeScope = Container.BeginLifetimeScope();
            return new DefaultDependencyInjectionScope(lifetimeScope);
        }
    }
}
