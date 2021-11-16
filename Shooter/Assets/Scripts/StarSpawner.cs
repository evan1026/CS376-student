using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour {

    public GameObject StarPrefab;
    public float SpawnInterval;

    private Bounds spawnerBounds;
    private float nextSpawn;

    void Start() {
        nextSpawn = 0.0f;
        spawnerBounds = GetComponent<BoxCollider2D>().bounds;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time >= nextSpawn) {
            float x = Random.Range(spawnerBounds.min.x, spawnerBounds.max.x);
            float y = spawnerBounds.center.y;
            Vector3 position = new Vector3(x, y, 1);

            Instantiate(StarPrefab, position, Quaternion.identity, gameObject.transform.parent);

            nextSpawn = Time.time + SpawnInterval;
        }
    }
}
