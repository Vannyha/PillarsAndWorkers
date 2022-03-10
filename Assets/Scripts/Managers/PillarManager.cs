using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Components;
using Context;
using Helpers;
using UnityEngine;

namespace Managers
{
    public class PillarManager : MonoBehaviour, IPillarManager
    {
        private IWorkerManager workerManager;
        private List<Pillar> pillars = new List<Pillar>();
        private float timer = 0f;

        [SerializeField] private Pillar pillarPrefab;
        [SerializeField] private List<Vector3> pillarsPosition;
        [SerializeField] private float changeTime = 5f;
        
        void OnEnable()
        {
            foreach (var pillarPosition in pillarsPosition)
            {
                pillars.Add(Instantiate(pillarPrefab, pillarPosition, Quaternion.identity));
            }
        }

        void Update()
        {
            if (!pillars.All(plr => plr.Inactive))
            {
                return;
            }

            if (changeTime <= (timer += Time.deltaTime))
            {
                Pillar pillarToFix = pillars.ElementAt(Random.Range(0, pillars.Count - 1));
                pillarToFix.SetPillarColor((GameColor) Random.Range(1, 3));
                workerManager.PillarFixRequest(pillarToFix);
                timer = 0f;
            }
        }

        public void SetupBeans(GameContext context)
        {
            workerManager = context.WorkerManagerInstance;
        }
    }
}
