using Context;
using UnityEngine;

namespace Managers
{
    public class WorkerManager : MonoBehaviour, IWorkerManager
    {
        private IPillarManager pillarManager;

        void Start()
        {
        
        }

        void Update()
        {
        
        }

        public void SetupBeans(GameContext context)
        {
            pillarManager = context.PillarManagerInstance;
        }
    }
}
