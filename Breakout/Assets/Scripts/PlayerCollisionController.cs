using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour {

    private Rigidbody2D rigidBody;

    public float BallSpeedAdd;
    public Vector2 PositionOffset;

    // Start is called before the first frame update
    void Start() {
        rigidBody = gameObject.transform.parent.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            var ballRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            var currVel = ballRigidbody.velocity.magnitude + BallSpeedAdd;
            var awayVector = ballRigidbody.position - (rigidBody.position + PositionOffset);
            awayVector = awayVector.normalized * currVel;
            ballRigidbody.velocity = awayVector;
        }
    }
}
