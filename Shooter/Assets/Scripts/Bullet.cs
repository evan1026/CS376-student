using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed;
    public static GameObject bulletPrefab;

    private string target;

    public void SetDirection(Vector2 dir) {
        GetComponent<Rigidbody2D>().velocity = dir.normalized * Speed;
    }

    public void SetTarget(string target) {
        this.target = target;
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

    public static void Fire(Vector2 position, Transform parent, Vector2 direction, string target) {
        var bullet = Instantiate(bulletPrefab, position, Quaternion.identity, parent).GetComponent<Bullet>();
        bullet.SetDirection(direction);
        bullet.SetTarget(target);
    }
}
