using System.Collections.Generic;
using DefaultNamespace;
using Gameplay.Spawners;
using UIEvents;
using UnityEngine;

namespace Gameplay
{
    public class Level : MonoBehaviour, IEventHandler
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Transform _terrainSpawnPoint;
        [SerializeField] private List<Spawner> _spawners;

        private Player _player;
        private GameObject _terrain;

        private void OnEnable()
        {
            EventsManager.Instance.Subscribe(EventKeys.LaunchThePlate, this);
        }

        private void OnDisable()
        {
            EventsManager.Instance.Unsubscribe(EventKeys.LaunchThePlate, this);
        }

        public void Create(LevelInfo info)
        {
            _player = Instantiate(info.Player, _playerSpawnPoint);
            
            _player.TakeGun(info.WeaponPrefab);
            _terrain = Instantiate(info.TerrainPrefab, _terrainSpawnPoint);
        }

        public void LaunchRandomSpawner()
        {
            _spawners.GetRandomElement().Launch();
        }

        public void OnEvent(string eventKey, params object[] pars)
        {
            switch (eventKey)
            {
                case EventKeys.LaunchThePlate:
                    LaunchRandomSpawner();
                    break;
            }
        }
    }
}