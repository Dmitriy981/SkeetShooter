using Gameplay;
using UnityEngine;
using UnityEngine.Serialization;

namespace Storage
{
    [CreateAssetMenu(menuName = "Custom/SpawnerSettings")]
    public class SpawnerSettings : ScriptableObject
    {
        [SerializeField] private Plate _platePrefab;
        
        [SerializeField] private float _flyTime;
        [SerializeField] private float _terrainHeight;

        public Plate PlatePrefab => _platePrefab;
        public float FlyTime => _flyTime;
        public float TerrainHeight => _terrainHeight;
    }
}