using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

    public Vector3 Velocity;

    // Update is called once per frame
    void Update() {
        transform.position += Velocity * Time.deltaTime;
    }
}
