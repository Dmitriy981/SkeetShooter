using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace UIEvents
{
    public class ButtonClickListener : MonoBehaviour
    {
        [EnumAttribute(typeof(EventKeys))][SerializeField] string _key;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }

        public void OnButtonClicked()
        {
            EventsManager.Instance.Send(_key);
        }
    }
}