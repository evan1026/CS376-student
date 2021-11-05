using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public Vector3 StartVelocity = new Vector3(2, 3, 0);

    // Start is called before the first frame update
    void Start() {
        GetComponent<Rigidbody2D>().velocity = StartVelocity;
    }

    // Update is called once per frame
    void Update() {

    }
}
