using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour {
    [Header("Prefab")]
	[SerializeField] GameObject ObstaclePrefab;

    [Header("Setting")]
    [SerializeField] int PoolCount = 4;
    [SerializeField] float ObstacleReleaseTime = 1f;
    [SerializeField, Range(1f, 20f)] float _obstacleSpeed = 16f;
    [SerializeField] float _obstacleBorderX = -12f;
    [SerializeField, Range(8f, 16f)] float _obstacleMaxY = 16f;
    [SerializeField, Range(0f, 8f)] float _obstacleMinY = 0f;

    public float ObstacleSpeed { get { return _obstacleSpeed; } }
    public float ObstacleBorderX { get { return _obstacleBorderX; } }
    public float ObstacleMaxY { get { return _obstacleMaxY; } }
    public float ObstacleMinY { get { return _obstacleMinY; } }
    public float lastHeight { get; private set; }

    Queue<Obstacle> pool = new Queue<Obstacle>();
    float accumulateReleaseTime;

    void Awake() {
        for(int i = 0; i < PoolCount; i++) {
            Obstacle obstacle = Instantiate(ObstaclePrefab, transform).GetComponent<Obstacle>();
            obstacle.SetPool(this);
            pool.Enqueue(obstacle);
        }
        lastHeight = Camera.main.orthographicSize;
    }

    void Update() {
        if(GameManager.State != GameManager.GameState.PLAY) return;

        accumulateReleaseTime += Time.deltaTime;

        if(accumulateReleaseTime >= ObstacleReleaseTime) {
            ResetAccumulateReleaseTime();
            ReleaseObstacle();
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Vector2(0, _obstacleMaxY), Vector2.right * 9f);
        Gizmos.DrawRay(new Vector2(0, _obstacleMinY), Vector2.right * 9f);
    }

    public void ReleaseObstacle() {
        Obstacle obstacle = pool.Dequeue();
        obstacle.SetRandomPosition();
        lastHeight = obstacle.transform.position.y;
        obstacle.Release();
        pool.Enqueue(obstacle);
    }

    public void ResetObstacle() {
        for(int i = 0; i < PoolCount; i++) {
            Obstacle obstacle = pool.Dequeue();
            obstacle.Reset();
            pool.Enqueue(obstacle);
        }
        lastHeight = Camera.main.orthographicSize;
    }

    public void ResetAccumulateReleaseTime() {
        accumulateReleaseTime = 0f;
    }
}
