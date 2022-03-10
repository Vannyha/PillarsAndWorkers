using Context;
using UnityEngine;

namespace Managers
{
    public class PillarManager : MonoBehaviour, IPillarManager
    {
        private IWorkerManager workerManager;
        
        void Start()
        {
        
        }

        void Update()
        {
        
        }

        public void SetupBeans(GameContext context)
        {
            workerManager = context.WorkerManagerInstance;
        }
    }
}
