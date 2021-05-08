﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    [Header("Child Object")]
	[SerializeField] SpriteRenderer UpsideRenderer;
	[SerializeField] SpriteRenderer DownsideRenderer;

    ObstaclePool obstaclePool;

    float holeHeight;
    float minY;
    float maxY;

    bool isMove;

    void Awake() {
        holeHeight = UpsideRenderer.bounds.min.y - DownsideRenderer.bounds.max.y;

        minY = 0f + holeHeight * 0.5f;
        maxY = Camera.main.orthographicSize * 2f - holeHeight * 0.5f;
    }

    void Update() {
        if(isMove) {
            transform.Translate(Vector2.left * obstaclePool.ObstacleSpeed * Time.deltaTime);

            if(transform.position.x <= obstaclePool.ObstacleBorderX) {
                Reset();
            }
        }
    }

    public void SetPool(ObstaclePool pool) {
        obstaclePool = pool;
    }

    public void SetRandomPosition() {
        float posX = transform.position.x;
        float calibrateMinY = Mathf.Max(obstaclePool.lastHeight - Camera.main.orthographicSize, minY);
        float calibrateMaxY = Mathf.Min(obstaclePool.lastHeight + Camera.main.orthographicSize, maxY);
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
        isMove = false;
    }
}
