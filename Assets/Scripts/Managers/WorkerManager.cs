using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Components;
using Context;
using Helpers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class WorkerManager : MonoBehaviour, IWorkerManager
    {
        private IPillarManager pillarManager;
        private List<Worker> workers = new List<Worker>();
        
        [SerializeField] private Worker workerPrefab;
        [SerializeField] private List<WorkerSetup> workersSetup;

        public void SetupBeans(GameContext context)
        {
            pillarManager = context.PillarManagerInstance;
        }
        
        public void OnEnable()
        {
            foreach (WorkerSetup workerSetup in workersSetup)
            {
                Worker tempWorker = 
                    Instantiate(workerPrefab, workerSetup.StartPosition, Quaternion.identity);
                tempWorker.SetStartPos(workerSetup.StartPosition);
                tempWorker.SetAvailableColors(workerSetup.WorkerColors);
                workers.Add(tempWorker);
            }
        }

        public void Update()
        {
            workers.ForEach(w => w.ProcessUpdate());
        }
    }

    [Serializable]
    public class WorkerSetup
    {
        public Vector3 StartPosition;
        public List<GameColor> WorkerColors;
    }
}
