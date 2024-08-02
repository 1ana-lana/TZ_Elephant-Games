using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonProvaider : Button
{
    public event Action<PointerEventData> PointerDown;
    public event Action<PointerEventData> PointerUp;

    public override void OnPointerDown(PointerEventData eventData)
    {
       PointerDown?.Invoke(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        PointerUp?.Invoke(eventData);
    }
}
