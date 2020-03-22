using System;

namespace SimpleWebServer.DependencyInjection
{
    public interface IDependencyInjectionScope : IDisposable
    {
        object Resolve(Type type);
        TType Resolve<TType>();
    }
}
