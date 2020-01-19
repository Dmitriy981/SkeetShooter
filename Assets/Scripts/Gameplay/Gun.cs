using System;
using DefaultNamespace;
using DG.Tweening;
using Managers;
using UIEvents;
using UnityEngine;

namespace Gameplay
{
    public class Gun : MonoBehaviour
    {
        public event Action<float> OnShotEvent;

        [SerializeField] private float _luckyShotProgressValue = 0.9f;
        [SerializeField] private AudioSource _fireSound;
        
        private Tweener preparingTweener = null;

        private void OnEnable()
        {
            ResetPreparing();
        }
        
        public void StartPreparingForShot(ILaunchObject currentTarget)
        {
            if (preparingTweener != null)
            {
                BreakPreparing();
            }

            ResetPreparing();
            preparingTweener = DOTween.To(() => 0f,
                val =>
                {
                    EventsManager.Instance.Send(EventKeys.OnPreparingUpdate, val);
                    
                    if (currentTarget.FlyProgress > _luckyShotProgressValue)
                    {
                        TryMakeShot(val);
                        BreakPreparing();
                    }
                },
                1f,
                StorageManager.Instance.PreparingStorage.GetPreparingTime(currentTarget.FlyProgress))
                    .OnComplete(OnCompletePreparing);
        }

        private void ResetPreparing()
        {
            EventsManager.Instance.Send(EventKeys.OnPreparingUpdate, 0.0f);
        }

        public void BreakPreparing()
        {
            ResetPreparing();
            preparingTweener.Kill();
            preparingTweener = null;
        }

        public void Shot()
        {
            _fireSound.Play(0);
        }

        private void TryMakeShot(float hitChance = 1f)
        {
            OnShotEvent?.Invoke(hitChance);
        }
        
        private void OnCompletePreparing()
        {
            TryMakeShot();
        }
    }
}