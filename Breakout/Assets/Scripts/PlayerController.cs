using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rigidBody;

    public float MoveSpeed;

    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        var horizontal = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector3(horizontal * MoveSpeed, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            var ballRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            var currVel = ballRigidbody.velocity.magnitude;
            var awayVector = ballRigidbody.position - rigidBody.position;
            awayVector = awayVector.normalized * currVel;
            ballRigidbody.velocity = awayVector;
        }
    }
}
