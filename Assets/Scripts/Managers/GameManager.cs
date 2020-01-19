using DefaultNamespace;
using DG.Tweening;
using Gameplay;
using Screens;
using UIEvents;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour, IEventHandler
    {
        [SerializeField] private Player _playerPrefab;
        
        private void Awake()
        {
            EventsManager.Instance.Subscribe(EventKeys.StartGame, this);
            ScreensManager.Instance.ShowScreen<MenuScreen>();

            DOTween.Init();
        }

        private void OnDestroy()
        {
            EventsManager.Instance.Unsubscribe(EventKeys.StartGame, this);
        }
        
        private void StartDefaultGame()
        {
            LevelInfo info = StorageManager.Instance.LevelsStorage.GetLevelInfo(LevelType.Default);
            info.Player = _playerPrefab;
            LevelManager.Instance.StartGame(info);
        }

        public void OnEvent(string eventKey, params object[] pars)
        {
            switch (eventKey)
            {
                case EventKeys.StartGame:
                    StartDefaultGame();
                    break;
            }
        }
    }
}