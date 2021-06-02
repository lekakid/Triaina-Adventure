using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    [Header("Child Object")]
	[SerializeField] SpriteRenderer UpsideRenderer;
	[SerializeField] SpriteRenderer DownsideRenderer;
    [SerializeField] GameObject Gem;

    [Header("Data Container")]
    [SerializeField] ScoreManager ScoreManager;

    ObstaclePool obstaclePool;

    float holeHeight;

    bool isMove;

    void Awake() {
        holeHeight = UpsideRenderer.bounds.min.y - DownsideRenderer.bounds.max.y;
    }

    void Update() {
        if(isMove) {
            transform.Translate(Vector2.left * obstaclePool.ObstacleSpeed * Time.deltaTime);

            if(transform.position.x <= obstaclePool.ObstacleBorderX) {
                Reset();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(GameManager.State != GameManager.GameState.PLAY) return;
        
        if(other.CompareTag("Player")) {
            ScoreManager.AddScore();
            Gem.SetActive(false);
        }
    }

    public void SetPool(ObstaclePool pool) {
        obstaclePool = pool;
    }

    public void SetRandomPosition() {
        float minY = obstaclePool.ObstacleMinY + holeHeight * 0.5f;
        float maxY = obstaclePool.ObstacleMaxY - holeHeight * 0.5f;
        float half = (maxY - minY) * 0.5f;

        float calibrateMinY = Mathf.Max(obstaclePool.lastHeight - half, minY);
        float calibrateMaxY = Mathf.Min(obstaclePool.lastHeight + half, maxY);

        float posX = transform.position.x;
        float posY = Random.Range(calibrateMinY, calibrateMaxY);

        transform.position = new Vector2(posX, posY);
    }

    public void SetSprite() {
        // TODO: 장애물 길이 따른 스프라이트 교체
    }

    public void Release() {
        isMove = true;
    }

    public void Reset() {
        transform.position = obstaclePool.transform.position;
        Gem.SetActive(true);
        isMove = false;
    }
}
