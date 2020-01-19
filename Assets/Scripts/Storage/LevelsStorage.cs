using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Storage
{
    [CreateAssetMenu(menuName = "Custom/LevelsStorage")]
    public class LevelsStorage : ScriptableObject
    {
        [SerializeField] private List<LevelInfo> _levelInfos;

        public LevelInfo GetLevelInfo(LevelType type)
        {
            return _levelInfos.Find(x => x.Type == type);
        }
    }
}