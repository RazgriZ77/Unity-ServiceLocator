using UnityEngine;
    
namespace HarryB97.Tools.ServiceLocator.Example {
    public class ExampleEntity : MonoBehaviour {
        // ==================== VARIABLES ===================
        #region Private Variables
        // Services
        [Service] private readonly IExampleService exampleService;
        #endregion
        
        // ==================== START ====================
        private void Awake() {
            // Services
            ServiceProvider.GetServices(this);
        }

        private void Start() {
            // Dependiendo del Scope escogido, saldrá un mensaje u otro
            exampleService.ExampleMethod();
        }
    }
}