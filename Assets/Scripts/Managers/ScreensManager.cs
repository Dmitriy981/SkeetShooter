using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Managers
{
    public class ScreensManager : SingletonMonoBehaivour<ScreensManager>
    {
        [SerializeField] private List<ScreenBase> _screens;
        [SerializeField] private Transform _screensTransform;
        
        private List<ScreenBase> _existedScreens = new List<ScreenBase>();
        private ScreenBase _currentScreen;

        private ScreenBase GetScreen<T>()
        {
            ScreenBase screen = _existedScreens.Find(x => x.name == typeof(T).Name);

            if (screen == null)
            {
                screen = Instantiate(_screens.Find(x => x.name == typeof(T).Name), _screensTransform);
            }
            
            return screen;
        }
        
        public void ShowScreen<T>() where T : ScreenBase
        {
            ScreenBase screen = GetScreen<T>();

            if (_currentScreen != null)
            {
                FinishScreenHide(_currentScreen);
            }
            
            if (screen == null)
            {
                return;
            }

            _currentScreen = screen;
            screen.Show();
        }

        public void HideScreen<T>() where T : ScreenBase
        {
            ScreenBase screen = GetScreen<T>();

            if (screen == null)
            {
                return;
            }

            FinishScreenHide(screen);
        }

        private void FinishScreenHide(ScreenBase screen)
        {
            screen.Hide();
        }
    }
}