using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

    static int ballCount = 0;

    public Vector3 StartVelocity = new Vector3(2, 3, 0);
    public float Speed = 5;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start() {
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
            Debug.Log("Fixed speed");
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
}
