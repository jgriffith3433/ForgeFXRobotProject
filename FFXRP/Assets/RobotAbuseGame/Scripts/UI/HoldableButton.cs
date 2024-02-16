using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoldableButton : Button
{
    [SerializeField] public UnityEvent OnHoldDownButton = null;
    [SerializeField] public UnityEvent OnLetGoButton = null;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        if (OnHoldDownButton != null)
        {
            OnHoldDownButton.Invoke();
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if (OnLetGoButton != null)
        {
            OnLetGoButton.Invoke();
        }
    }
}
