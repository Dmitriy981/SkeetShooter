using System;
using Gameplay;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public struct LevelInfo
    {
        public LevelType Type;
        public Level LevelPrefab;
        public GameObject TerrainPrefab;
        public Gun WeaponPrefab;
        
        [NonSerialized] public Player Player;
    }
}