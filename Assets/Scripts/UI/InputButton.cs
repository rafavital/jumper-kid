using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onDown, onUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        onDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        onUp?.Invoke();
    }
}
