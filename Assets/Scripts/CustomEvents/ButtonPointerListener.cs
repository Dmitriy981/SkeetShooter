using DefaultNamespace;
using UIEvents;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPointerListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [EnumAttribute(typeof(EventKeys))][SerializeField] string _downKey;
    [EnumAttribute(typeof(EventKeys))][SerializeField] string _upKey;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        EventsManager.Instance.Send(_downKey);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EventsManager.Instance.Send(_upKey);
    }
}
