using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Storage
{
    [CreateAssetMenu(menuName = "Custom/PreparingStorage")]
    public class PreparingStorage : ScriptableObject
    {
        [SerializeField] private List<PreparingInfo> _preparingSettings;

        public float GetPreparingTime(float currentTime)
        {
            foreach (PreparingInfo preparingInfo in _preparingSettings)
            {
                if (currentTime < preparingInfo.MaxTimeValue)
                {
                    return preparingInfo.PreparingTime;
                }
            }

            return 1.0f;
        }
    }
}