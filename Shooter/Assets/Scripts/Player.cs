using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float MoveSpeed;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        var horizontal = Input.GetAxis("Horizontal");
        var desiredSpeed = new Vector2(horizontal * MoveSpeed, 0);
        var speedDiff = desiredSpeed - rigidBody.velocity;
        rigidBody.AddForce(speedDiff, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            blowUp(collision.gameObject);
        }
    }

    private void blowUp(GameObject other) {
        Destroy(gameObject);
        Destroy(other);
    }
}
