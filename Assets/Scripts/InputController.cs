using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    [Header("Events")]
    [SerializeField] GameEventSO PauseEvent;
    [SerializeField] GameEventSO ResumeEvent;

    Player player;

    void Awake() {
        player = GetComponent<Player>();
    }

	void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(GameManager.State == GameManager.GameState.PLAY) {
                PauseEvent.Dispatch();
            }
            else if(GameManager.State == GameManager.GameState.PAUSE) {
                ResumeEvent.Dispatch();
            }
        }

        if(Input.anyKeyDown) {
            player.Jump();
        }
    }
}
