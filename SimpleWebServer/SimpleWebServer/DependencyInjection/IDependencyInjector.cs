using System;

namespace SimpleWebServer.DependencyInjection
{
    public interface IDependencyInjector
    {
        void Register<TType, TImplementation>() where TImplementation : TType;
        void Register(Type type, Type implementation);
        void RegisterScoped<TType, TImplementation>() where TImplementation : TType;
        void RegisterScoped(Type type, Type implementation);
        void RegisterSingleton<TType, TImplementation>() where TImplementation : TType;
        void RegisterSingleton(Type type, Type implementation);
        IDependencyInjectionScope GetScope();
    }
}
