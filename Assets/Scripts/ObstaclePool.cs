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

    public float ObstacleSpeed { get { return _obstacleSpeed; } }
    public float ObstacleBorderX { get { return _obstacleBorderX; } }
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
        accumulateReleaseTime += Time.deltaTime;

        if(accumulateReleaseTime >= ObstacleReleaseTime) {
            ResetAccumulateReleaseTime();
            ReleaseObstacle();
        }
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
