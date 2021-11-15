using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float MoveSpeed;
    public float ShotCooldown;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public GameObject ExplosionPrefab;

    private Rigidbody2D rigidBody;
    private float shotCooldown;
    private Vector2 bulletOffset;

    // Start is called before the first frame update
    void Start() {
        Bullet.bulletPrefab = BulletPrefab;

        rigidBody = GetComponent<Rigidbody2D>();
        shotCooldown = 0;

        var bounds = GetComponent<Collider2D>().bounds;
        bulletOffset = new Vector2(0, bounds.size.y + BulletPrefab.GetComponent<Collider2D>().bounds.size.y + 0.1f);
    }

    // Update is called once per frame
    void Update() {
        var horizontal = Input.GetAxis("Horizontal");
        var desiredSpeed = new Vector2(horizontal * MoveSpeed, 0);
        var speedDiff = desiredSpeed - rigidBody.velocity;
        rigidBody.AddForce(speedDiff, ForceMode2D.Impulse);

        if (shotCooldown > 0) {
            shotCooldown -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && shotCooldown <= 0) {
            shoot();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            blowUp(collision.gameObject);
        }
    }

    private void blowUp(GameObject other) {
        Instantiate(ExplosionPrefab, other.transform.position, Quaternion.identity, transform.parent);
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        Destroy(gameObject);
        Destroy(other);
    }

    private void shoot() {
        Bullet.Fire(rigidBody.position + bulletOffset, gameObject.transform.parent, new Vector2(0, 1), "Enemy", BulletSpeed);
        shotCooldown = ShotCooldown;
    }
}
