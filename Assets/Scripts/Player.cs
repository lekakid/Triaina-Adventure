using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Setting")]
    [Range(1f, 100f)]
    [SerializeField] float jumpPower = 10f;

    [Header("Events")]
    [SerializeField] GameEventSO GameOverEvent;

    // Component
    new Rigidbody2D rigidbody;

    // Variable
    Vector2 defaultPos;

    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();

        defaultPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Obstacle")) {
            GameOverEvent.Dispatch();
        }
    }

    public void Reset() {
        transform.position = defaultPos;
    }

    public void Jump() {
        rigidbody.velocity = Vector2.up * jumpPower;
    }
}
