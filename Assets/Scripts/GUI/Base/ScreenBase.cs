using UnityEngine;

namespace DefaultNamespace
{
    public class ScreenBase : MonoBehaviour, IScreen
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}