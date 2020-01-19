using System;
using DefaultNamespace;
using Storage;
using UIEvents;
using UnityEngine;

namespace Gameplay
{
    public class Plate : MonoBehaviour, ILaunchObject
    {
        [SerializeField] private Rigidbody _plateBody;
        [SerializeField] private AudioSource _destroyAudio;

        private float _launchTime;
        private SpawnInfo _currentSpawnInfo;

        public float FlyProgress => (Time.realtimeSinceStartup - _launchTime) / _currentSpawnInfo.FlyTime;
        
        public void BlowUp()
        {
            EventsManager.Instance.Send(EventKeys.PlateDestroy);
            Destroy(gameObject);
        }
        
        public void Launch(SpawnInfo spawnInfo)
        {
            _currentSpawnInfo = spawnInfo;
            
            float startSpeedLength =
                (-Physics.gravity.y * spawnInfo.FlyTime * spawnInfo.FlyTime - 2.0f * spawnInfo.SpawnHeight) /
                (2.0f * spawnInfo.FlyTime * Mathf.Sin(spawnInfo.Angle));
                        
            _plateBody.AddForce(spawnInfo.Direction * startSpeedLength, ForceMode.Impulse);

            _launchTime = Time.realtimeSinceStartup;

            transform.rotation = transform.localRotation;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.layer == LayerKeys.Terrain)
            {
                _destroyAudio.Play();
                BlowUp();
            }
        }
    }
}