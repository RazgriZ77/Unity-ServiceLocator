using System;

namespace HarryB97.Tools.ServiceLocator {
    public interface IServiceScope {
        bool GetService<T>(out T _service);
        bool GetService(Type _type, out object _service);
    }
}