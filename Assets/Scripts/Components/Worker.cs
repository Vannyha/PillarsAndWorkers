using System.Collections.Generic;
using Helpers;
using UnityEngine;
using UnityEngine.AI;

namespace Components
{
    public class Worker : MonoBehaviour
    {
        private const float FixDistance = 2f;
        
        private Vector3 startPos = Vector3.zero;
        private Pillar currentPillar;
        private bool inWork = false;
        private List<GameColor> availableColors = new List<GameColor>();

        private Transform stashedPillarTransform;
        
        [SerializeField] private NavMeshAgent navMeshAgent;

        public bool InWork => inWork;
        public List<GameColor> AvailableColors => availableColors;
        
        public void SetPillarToFix(Pillar pillar)
        {
            currentPillar = pillar;
            stashedPillarTransform = pillar.transform;
            navMeshAgent.SetDestination(pillar.gameObject.transform.position);
            inWork = true;
        }

        public void ProcessUpdate()
        {
            if (!inWork)
            {
                return;
            }

            if (Vector3.Distance(transform.position, stashedPillarTransform.position) > FixDistance)
            {
                return;
            }
            
            currentPillar.FixPillar();
            currentPillar = null;
            stashedPillarTransform = null;
            navMeshAgent.SetDestination(startPos);
            inWork = false;
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