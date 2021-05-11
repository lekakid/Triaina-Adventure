using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentElement : MonoBehaviour {
	[SerializeField, Range(1f, 10f)] float speed = 6f;
    [SerializeField] float resetPosX = -2f;
    [SerializeField, Range(3f, 16f)] float MaxHeight = 4f;
    [SerializeField, Range(3f, 16f)] float MinHeight = 4f;

    public bool isMove { get; private set; }

    float defaultPosX;
    Queue<EnvironmentElement> targetQueue;

    void Awake() {
        defaultPosX = transform.position.x;
    }

    void Update() {
        if(isMove) {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if(transform.position.x <= resetPosX) {
                Finish();
            }
        }
    }

    public void Release() {
        float height = Random.Range(MinHeight, MaxHeight);
        transform.position = new Vector2(transform.position.x, height);
        isMove = true;
    }

    public void SetRestoreQueue(Queue<EnvironmentElement> targetQueue) {
        this.targetQueue = targetQueue;
    }

    public void Finish() {
        isMove = false;
        transform.position = new Vector2(defaultPosX, transform.position.y);
        targetQueue.Enqueue(this);
    }
}
