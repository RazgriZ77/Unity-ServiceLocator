using System;
using UnityEngine;

namespace HarryB97.Tools.ServiceLocator {
    public abstract class ServiceScope : IServiceScope {
        // ==================== VARIABLES ===================
        #region Private Variables
        private IServiceLocator locator;
        #endregion

        // ==================== INICIO ====================
        protected ServiceScope(IServiceLocator _locator = null) {
            locator = _locator == null ? new ServiceLocator() : _locator;
            Configure(locator);
        }
        
        // ==================== METHODS ====================
        protected abstract void Configure(IServiceLocator _locator);
        
        public bool GetService<T>(out T _service) {
            try {
                _service = locator.Get<T>();
                return true;
                
            } catch (Exception _exc) {
                Debug.LogError($"Fallo al recuperar el servicio de tipo {typeof(T)}: {_exc.Message}");
                
                _service = default;
                return false;
            }
        }

        public bool GetService(Type _type, out object _service) {
            try {
                _service = locator.Get(_type);
                return true;
                
            } catch (Exception _exc) {
                Debug.LogError($"Fallo al recuperar el servicio de tipo {_type}: {_exc.Message}");
                
                _service = default;
                return false;
            }
        }
    }
}