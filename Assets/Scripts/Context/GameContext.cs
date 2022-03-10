using System.Collections.Generic;
using System.Linq;
using Managers;
using UnityEngine;

namespace Context
{
    public class GameContext : MonoBehaviour
    {
        [SerializeField] private WorkerManager workerManager;
        [SerializeField] private PillarManager pillarManager;

        public IPillarManager PillarManagerInstance => pillarManager;
        public IWorkerManager WorkerManagerInstance => workerManager;
        
        public void Awake()
        {
            IEnumerable<GameObject> objects = gameObject.scene.GetRootGameObjects().Where(go => go.TryGetComponent<IBean>(out _));
            objects.Select(go => go.GetComponent<IBean>()).ToList().ForEach(bean => bean.SetupBeans(this));
            objects.ToList().ForEach(obj => obj.SetActive(true));
        }
    }
}