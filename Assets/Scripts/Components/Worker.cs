using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.AI;

namespace Components
{
    public class Worker : MonoBehaviour
    {
        private Vector3 startPos = Vector3.zero;
        private Pillar currentPillar;
        private bool inWork = false;
        private List<GameColor> availableColors;
        
        [SerializeField] private NavMeshAgent navMeshAgent;

        public bool InWork => inWork;
        public List<GameColor> AvailableColors => availableColors;
        
        public void SetPillarToFix(Pillar pillar)
        {
            currentPillar = pillar;
            inWork = true;
        }

        public void ProcessUpdate()
        {
            if (inWork)
            {
                
            }
        }

        public void SetStartPos(Vector3 pos)
        {
            startPos = pos;
        }

        public void SetAvailableColors(List<GameColor> colors)
        {
            availableColors.Clear();
            availableColors.AddRange(colors);
        }
    }
}