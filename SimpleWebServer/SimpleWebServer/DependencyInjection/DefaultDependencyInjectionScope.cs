using System;
using Autofac;

namespace SimpleWebServer.DependencyInjection
{
    public class DefaultDependencyInjectionScope : IDependencyInjectionScope
    {
        private readonly ILifetimeScope lifetimeScope;

        public DefaultDependencyInjectionScope(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        public void Dispose()
        {
            lifetimeScope.Dispose();
        }

        public object Resolve(Type type)
        {
            return lifetimeScope.Resolve(type);
        }

        public TType Resolve<TType>()
        {
            return lifetimeScope.Resolve<TType>();
        }
    }
}
