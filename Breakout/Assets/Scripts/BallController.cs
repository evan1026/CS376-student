using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

    static int ballCount = 0;

    public Vector3 StartVelocity = new Vector3(2, 3, 0);
    public float Speed = 5;
    public bool DebugLogging = false;

    private Rigidbody2D rigidBody;
    private AudioController audioController;

    // Start is called before the first frame update
    void Start() {
        audioController = FindObjectOfType<AudioController>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = StartVelocity.normalized * Speed;
        ballCount += 1;
    }

    // Update is called once per frame
    void Update() {
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
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnDestroy() {
        ballCount -= 1;
        if (ballCount == 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (!collision.gameObject.CompareTag("Brick")) {
            audioController.playBallBounce();
        }
    }
}
