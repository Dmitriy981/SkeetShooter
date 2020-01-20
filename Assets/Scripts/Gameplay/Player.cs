using System;
using DefaultNamespace;
using Managers;
using UIEvents;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform _gunPoint;
        [SerializeField] private TargetRaycaster _targetRaycaster;
        [SerializeField] private CameraController _cameraController;

        private Gun _gun;

        private void OnEnable()
        {
            _targetRaycaster.OnCollideStartedEvent += TargetRaycaster_OnCollideStartedEvent;
            _targetRaycaster.OnCollideEndedEvent += TargetRaycaster_OnCollideEndedEvent;
        }

        private void OnDisable()
        {
            _targetRaycaster.OnCollideStartedEvent -= TargetRaycaster_OnCollideStartedEvent;
            _targetRaycaster.OnCollideEndedEvent -= TargetRaycaster_OnCollideEndedEvent;

            if (_gun != null)
            {
                _gun.OnShotEvent -= Gun_OnShotEvent;
            }
        }

        public void TakeGun(Gun gun)
        {
            _gun = Instantiate(gun, _gunPoint);
            
            _gun.OnShotEvent += Gun_OnShotEvent;
        }

        private void TargetRaycaster_OnCollideStartedEvent()
        {
            ILaunchObject plate = _targetRaycaster.TargetCollidedObject.GetComponentInParent<ILaunchObject>();
            
            _gun.StartPreparingForShot(plate);
        }
        
        private void TargetRaycaster_OnCollideEndedEvent()
        {
            _gun.BreakPreparing();
        }

        private void Gun_OnShotEvent(float hitChance)
        {
            if (Random.Range(0.0f, 1.0f) <= hitChance)
            {
                ILaunchObject plate = _targetRaycaster.TargetCollidedObject.GetComponentInParent<ILaunchObject>();
                plate.BlowUp();
                
                _gun.Shot();
                _cameraController.ReturnCameraToStart();
            }
        }
    }
}