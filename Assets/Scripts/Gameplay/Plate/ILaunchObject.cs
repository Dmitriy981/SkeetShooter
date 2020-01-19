using DefaultNamespace;
using Storage;
using UnityEngine;

namespace Gameplay
{
    public interface ILaunchObject
    {
        float FlyProgress { get; }
        void Launch(SpawnInfo info);
        void BlowUp();
    }
}