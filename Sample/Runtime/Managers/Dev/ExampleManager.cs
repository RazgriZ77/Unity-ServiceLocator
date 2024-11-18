using UnityEngine;

namespace HarryB97.Tools.ServiceLocator.Example.Dev {
    public class ExampleManager : IExampleService {
        // ==================== START ====================
        public ExampleManager() {
            Debug.Log("Created Example Manager in Dev Scope");
        }
        
        // ==================== METHODS ====================
        #region IExampleService
        void IExampleService.ExampleMethod() {
            Debug.Log("Example in Develop Scope!");
        }
        #endregion
    }
}