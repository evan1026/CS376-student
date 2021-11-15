using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed;

    public void SetDirection(Vector2 dir) {
        GetComponent<Rigidbody2D>().velocity = dir.normalized * Speed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        blowUp(collision.gameObject);

        if (collision.gameObject.CompareTag("Enemy")) {
            Scoring.AddScore(100);
        }
    }

    private void blowUp(GameObject other) {
        Destroy(gameObject);
        if (other.CompareTag("Enemy") || other.CompareTag("Player")) {
            Destroy(other);
        }
    }
}
