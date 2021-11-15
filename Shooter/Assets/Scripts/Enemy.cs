using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float DownSpeed;
    public float WaveAmplitude;
    public float WaveSpeed;

    private float phaseOffset;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start() {
        phaseOffset = Random.Range(0.0f, 2 * Mathf.PI);
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        float xSpeed = WaveAmplitude * Mathf.Cos(WaveSpeed * Time.fixedTime + phaseOffset);
        Vector2 vel = new Vector2(xSpeed, -DownSpeed);
        rigidBody.velocity = vel;
    }
}
