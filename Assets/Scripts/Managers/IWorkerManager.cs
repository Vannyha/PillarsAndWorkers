using Components;
using Context;

namespace Managers
{
    public interface IWorkerManager: IBean
    {
        void PillarFixRequest(Pillar pillar);
    }
}