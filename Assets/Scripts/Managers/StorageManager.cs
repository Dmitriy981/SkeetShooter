using Storage;
using UnityEngine;

namespace Managers
{
    public class StorageManager : SingletonMonoBehaivour<StorageManager>
    {
        [SerializeField] private LevelsStorage _levelsStorage;
        [SerializeField] private PreparingStorage _preparingStorage;
        
        public LevelsStorage LevelsStorage => _levelsStorage;
        public PreparingStorage PreparingStorage => _preparingStorage;
    }
}