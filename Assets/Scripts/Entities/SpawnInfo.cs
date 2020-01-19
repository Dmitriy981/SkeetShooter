using Storage;
using UnityEngine;

namespace DefaultNamespace
{
    public struct SpawnInfo
    {
        public Vector3 Direction;
        public float Angle;
        public float FlyTime;
        public float SpawnHeight;
        
        public SpawnInfo(SpawnerSettings settings, Transform launcherTransform)
        {
            FlyTime = settings.FlyTime;
            Direction = launcherTransform.forward;
            Angle = launcherTransform.eulerAngles.x;
            SpawnHeight = launcherTransform.position.y - settings.TerrainHeight;
        }
    }
}