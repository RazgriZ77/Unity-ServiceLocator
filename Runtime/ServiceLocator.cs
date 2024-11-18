using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace HarryB97.Tools.ServiceLocator {
    public class ServiceLocator : IServiceLocator {
        // ==================== VARIABLES ===================
        #region Private Variables
        private readonly ConcurrentDictionary<Type, object> services = new();
        #endregion

        // ==================== METHODS ====================
        public void Register<T>(T _service) => Register(typeof(T), _service);
        public void Register(Type _type, object _service) {
            if (_service == null) throw new ArgumentNullException(nameof(_service));
            if (!_type.IsAssignableFrom(_service.GetType())) throw new ArgumentException($"Este servicio no es asignable para el tipo: {_type}");
            if (!services.TryAdd(_type, _service)) throw new ArgumentException($"El servicio de tipo {_type} ya se encuentra registrado");
        }

        public bool Unregister<T>(T _service) => Unregister(typeof(T), _service);
        public bool Unregister(Type _type, object _service) {
            if (_type == null) throw new ArgumentNullException(nameof(_type));
            return services.TryRemove(_type, out _);
        }
        
        public T Get<T>() => (T)Get(typeof(T));
        public object Get(Type _type) {
            if (_type == null) throw new ArgumentNullException(nameof(_type));
            if (!services.TryGetValue(_type, out object _value)) throw new KeyNotFoundException($"Service of type {_type} is not registered");

            return _value;
        }

        public bool IsRegistered<T>() => IsRegistered(typeof(T));
        public bool IsRegistered(Type _type) {
            if(_type == null) throw new ArgumentNullException(nameof(_type));
            return services.ContainsKey(_type);
        }
    }
}