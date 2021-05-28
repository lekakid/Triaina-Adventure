using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DownOnlyButton : Selectable {
	public UnityEvent OnButtonDown;

    public override void OnPointerDown(PointerEventData eventData) {
        if(!IsActive() || !IsInteractable()) return;

        base.OnPointerDown(eventData);
        OnButtonDown.Invoke();
    }
}
