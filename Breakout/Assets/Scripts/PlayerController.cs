using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidBody;

    public float MoveSpeed;
    public float BallSpeedAdd;
    public Vector2 PositionOffset;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        var horizontal = Input.GetAxis("Horizontal");
        var desiredSpeed = new Vector2(horizontal * MoveSpeed, 0);
        var speedDiff = desiredSpeed - rigidBody.velocity;
        rigidBody.AddForce(speedDiff, ForceMode2D.Impulse);
    }

    bool topCollision(Collision2D collision) {
        Vector3 contactPoint = collision.contacts[0].point;
        Collider2D ourCollider = collision.otherCollider;
        Vector3 center = ourCollider.bounds.center;

        var rectWidth = ourCollider.bounds.size.x;

        if (contactPoint.y > center.y &&
                (contactPoint.x < center.x + rectWidth / 2 &&
                 contactPoint.x > center.x - rectWidth / 2)) {
            return true;
        }

        return false;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball") && topCollision(collision)) {
            var ballRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            var currVel = ballRigidbody.velocity.magnitude + BallSpeedAdd;
            var awayVector = ballRigidbody.position - (rigidBody.position + PositionOffset);
            awayVector = awayVector.normalized * currVel;
            ballRigidbody.velocity = awayVector;
        }
    }
}
