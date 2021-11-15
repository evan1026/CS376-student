using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public static GameObject bulletPrefab;

    private string target;
    private float speed;

    public void SetDirection(Vector2 dir) {
        GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
    }

    public void SetTarget(string target) {
        this.target = target;
    }

    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        blowUp(collision.gameObject);

    }

    private void blowUp(GameObject other) {
        bool hitTarget = other.CompareTag(target);
        bool hitWall = other.CompareTag("Wall");
        bool hitEnemy = other.CompareTag("Enemy");

        if (hitTarget || hitWall) {
            Destroy(gameObject);

            if (hitTarget) {
                if (hitEnemy) {
                    Scoring.AddScore(100);
                }
                Destroy(other);
            }
        }
    }

    public static void Fire(Vector2 position, Transform parent, Vector2 direction, string target, float speed) {
        var bullet = Instantiate(bulletPrefab, position, Quaternion.identity, parent).GetComponent<Bullet>();
        bullet.SetSpeed(speed);
        bullet.SetDirection(direction);
        bullet.SetTarget(target);
    }
}
