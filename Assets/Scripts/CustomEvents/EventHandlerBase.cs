using UnityEngine;

namespace UIEvents
{
    public abstract class EventHandlerBase : MonoBehaviour, IEventHandler
    {
        public abstract void OnEvent(string eventKey, params object[] pars);
    }
}