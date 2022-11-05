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
    [SerializeField] GameEventSO StartEvent;
    [SerializeField] GameEventSO GameOverEvent;

    [Header("Objects")]
    [SerializeField] SoundManager SoundManager;
    [SerializeField] RuntimeAnimatorController specialController;

    // Component
    new Rigidbody2D rigidbody;
    [SerializeField] ParticleSystem particle;
    Animator animator;

    // Variable
    Vector2 defaultPos;

    void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        defaultPos = transform.position;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("Obstacle")) {
            GameOverEvent.Dispatch();
        }
    }

    public void Reset() {
        transform.position = defaultPos;
        if(GameManager.isSpecial) {
            animator.runtimeAnimatorController = specialController;
        }
    }

    public void Jump() {
        if(Time.timeScale < 1f) return;
        
        if(!rigidbody.simulated) {
            StartEvent.Dispatch();
        }
        
        rigidbody.velocity = Vector2.up * jumpPower;
        PlayRandomJumpSFX();
        particle.Play();
    }

    void PlayRandomJumpSFX() {
        int r = Random.Range(1, 6);
        SoundManager.PlaySFX($"Jump{r}");
    }
}
