using SimpleWebServer.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebServer
{
    public interface IServerBuilder
    {
        void SetPort(int port);
        void SetDependencyInjector(IDependencyInjector dependencyInjector);
        void RegisterDependencies(Action<IDependencyInjector> configuration);
        IServer Build();
    }
}
