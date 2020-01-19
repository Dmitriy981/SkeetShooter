using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class PreparingInfo
    {
        [Range(0, 1)]
        public float MaxTimeValue;
        public float PreparingTime;
    }
}