using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject EnemyPrefab;
    public float SpawnInterval;
    public float DifficultyScale;

    private Bounds spawnerBounds;
    private float nextSpawn;

    void Start() {
        nextSpawn = 0.0f;
        spawnerBounds = GetComponent<BoxCollider2D>().bounds;
    }

    void Update() {
        if (Time.time >= nextSpawn) {
            float x = Random.Range(spawnerBounds.min.x, spawnerBounds.max.x);
            float y = spawnerBounds.center.y;
            Vector3 position = new Vector3(x, y, 1);
            Instantiate(EnemyPrefab, position, Quaternion.identity, gameObject.transform.parent);
            nextSpawn = Time.time + SpawnInterval;
            SpawnInterval *= DifficultyScale;
        }
    }
}
