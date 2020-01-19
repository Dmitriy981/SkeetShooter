using DefaultNamespace;
using Storage;
using UnityEngine;

namespace Gameplay.Spawners
{
    public class Spawner : MonoBehaviour, ISpawner
    {
        [SerializeField] private SpawnerSettings _settings;
        [SerializeField] private AudioSource _launchAudio;

        private ILaunchObject _currentPlate;
        
        public void Launch()
        {
            _currentPlate = Instantiate(_settings.PlatePrefab, transform);
            _currentPlate.Launch(new SpawnInfo(_settings, transform));
            
            _launchAudio.Play();
        }
    }
}