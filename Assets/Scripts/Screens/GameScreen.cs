using DefaultNamespace;
using DG.Tweening;
using UIEvents;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class GameScreen : ScreenBase, IEventHandler
    {
        [SerializeField] Image _target;
        [SerializeField] Button[] _launchButtons;

        private void OnEnable()
        {
            EventsManager.Instance.Subscribe(EventKeys.OnPreparingUpdate, this);
            EventsManager.Instance.Subscribe(EventKeys.PlayerIsReady, this);

            foreach (Button launchButton in _launchButtons)
            {
                launchButton.onClick.AddListener(OnLaunchClicked);
            }
        }

        private void OnDisable()
        {
            EventsManager.Instance.Unsubscribe(EventKeys.OnPreparingUpdate, this);
            EventsManager.Instance.Unsubscribe(EventKeys.PlayerIsReady, this);
        }

        public void OnEvent(string eventKey, params object[] pars)
        {
            switch (eventKey)
            {
                case EventKeys.OnPreparingUpdate:
                    OnPreparingUpdated((float)pars[0]);
                    break;
                
                case EventKeys.PlayerIsReady:
                    SwitchLaunchButtonsVisibility(true);
                    break;
            }
        }

        private void SwitchLaunchButtonsVisibility(bool isActive)
        {
            foreach (Button launchButton in _launchButtons)
            {
                launchButton.gameObject.SetActive(isActive);
            }
        }

        private void OnPreparingUpdated(float currentValue)
        {
            _target.fillAmount = currentValue;
        }

        private void OnLaunchClicked()
        {
            SwitchLaunchButtonsVisibility(false);
        }
    }
}