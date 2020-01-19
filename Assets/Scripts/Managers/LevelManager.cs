using DefaultNamespace;
using Gameplay;
using Screens;

namespace Managers
{
    public class LevelManager : SingletonMonoBehaivour<LevelManager>
    {
        private Level _currentLevel;
        
        public void StartGame(LevelInfo info)
        {
            ScreensManager.Instance.ShowScreen<GameScreen>();
            
            _currentLevel = Instantiate(info.LevelPrefab);
            _currentLevel.Create(info);
        }
    }
}