using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float DownSpeed;
    public float WaveAmplitude;
    public float WaveSpeed;
    public float ShotCooldown;
    public GameObject BulletPrefab;

    private float phaseOffset;
    private float nextShot;
    private Rigidbody2D rigidBody;
    private Vector2 bulletOffset;

    void Start() {
        phaseOffset = Random.Range(0.0f, 2 * Mathf.PI);
        rigidBody = GetComponent<Rigidbody2D>();

        nextShot = Time.time + ShotCooldown;

        var bounds = GetComponent<Collider2D>().bounds;
        bulletOffset = new Vector2(0, - (bounds.size.y + BulletPrefab.GetComponent<Collider2D>().bounds.size.y + 0.1f));
    }

    void Update() {
        if (Time.time >= nextShot) {
            Bullet.Fire(rigidBody.position + bulletOffset, gameObject.transform.parent, new Vector2(0, -1), "Player");
        }
    }

    void FixedUpdate() {
        float xSpeed = WaveAmplitude * Mathf.Cos(WaveSpeed * Time.fixedTime + phaseOffset);
        Vector2 vel = new Vector2(xSpeed, -DownSpeed);
        rigidBody.velocity = vel;
    }
}
