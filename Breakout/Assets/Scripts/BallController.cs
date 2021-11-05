using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour {

    static int ballCount = 0;

    public Vector3 StartVelocity = new Vector3(2, 3, 0);

    // Start is called before the first frame update
    void Start() {
        GetComponent<Rigidbody2D>().velocity = StartVelocity;
        ballCount += 1;
    }

    // Update is called once per frame
    void Update() {

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
