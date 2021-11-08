using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    static int ballCount = 0;

    public Vector3 StartVelocity = new Vector3(2, 3, 0);
    public float Speed = 5;
    public bool DebugLogging = false;

    private Rigidbody2D rigidBody;
    private AudioController audioController;
    private Rigidbody2D player;
    private FixedJoint2D fixedJoint;
    private bool captured = false;

    // Start is called before the first frame update
    void Start() {
        audioController = FindObjectOfType<AudioController>();
        player = FindObjectOfType<PlayerController>().gameObject.GetComponent<Rigidbody2D>();
        fixedJoint = GetComponent<FixedJoint2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector3(0,0,0);
        ballCount += 1;
        Capture();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (!captured) {
            // Sometimes speed changes and I don't know why. Easiest fix is to say if it changes
            // a lot we just get the direction we were heading and fix the speed
            if (Mathf.Abs(rigidBody.velocity.magnitude - Speed) > 0.1) {
                var direction = rigidBody.velocity.normalized;
                rigidBody.velocity = direction * Speed;

                if (DebugLogging) {
                    Debug.Log("Fixed speed");
                }
            }

            // Rarely the ball can get stuck just going left and right and it will never come
            // down. To fix this, if we detect this case, we give the ball a slight downward
            // trajectory
            if (Mathf.Abs(rigidBody.velocity.y) <= 0.01) {
                var vel = rigidBody.velocity;
                vel.y = -0.1f;
                var direction = vel.normalized;
                rigidBody.velocity = direction * Speed;

                if (DebugLogging) {
                    Debug.Log("Unstuck");
                }
            }
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Launch();
        }
    }

    void Capture() {
        if (!captured) {
            captured = true;
            fixedJoint.connectedBody = player;
            fixedJoint.enabled = true;
        }
    }

    void Launch() {
        if (captured) {
            captured = false;
            fixedJoint.connectedBody = null;
            fixedJoint.enabled = false;
            rigidBody.velocity = StartVelocity.normalized * Speed;
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnDestroy() {
        ballCount -= 1;
        if (ballCount == 0) {
            var endGame = FindObjectOfType<EndGame>(true);
            if (endGame != null) {
                endGame.Enter();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (!collision.gameObject.CompareTag("Brick")) {
            audioController.playBallBounce();
        }
    }
}
