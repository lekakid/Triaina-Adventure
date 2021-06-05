using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour {
	public enum Category {
        TITLE, CUTSCENE, PLAY, GAMEOVER
    }

    Category? currentCategory;
    Category? prevCategory;
    [System.Serializable]
    public class InputEvent {
        public Category Category;
        public UnityEvent OnEscapeDown;
        public UnityEvent OnAnyKeyDown;
    }

    [SerializeField] List<InputEvent> EventList;
    Dictionary<Category?, InputEvent> EventDictionary;
    InputEvent currentInputEvent;

    void Awake() {
        EventDictionary = new Dictionary<Category?, InputEvent>();

        foreach(InputEvent e in EventList) {
            EventDictionary.Add(e.Category, e);
        }
    }

    void Update() {
        if(currentInputEvent == null) return;
        if(Input.touchCount > 0 || Input.GetMouseButtonDown(0)) return;
        
        if(currentInputEvent.OnEscapeDown != null && Input.GetKeyDown(KeyCode.Escape)) {
            currentInputEvent.OnEscapeDown.Invoke();
            return;
        }

        if(currentInputEvent.OnAnyKeyDown != null && Input.anyKeyDown) {
            currentInputEvent.OnAnyKeyDown.Invoke();
            return;
        }
    }

    public void SetCategory(string category) {
        Category c;
        
        if(Enum.TryParse<Category>(category, out c)) {
            prevCategory = currentCategory;
            currentCategory = c;
            currentInputEvent = EventDictionary[c];
        }
    }

    public void SetPrevCategory() {
        if(prevCategory != null) {
            currentCategory = prevCategory;
            currentInputEvent = EventDictionary[prevCategory];
        }
    }

    public void Enable() {
        enabled = true;
    }

    public void Disable() {
        enabled = false;
    }
}
