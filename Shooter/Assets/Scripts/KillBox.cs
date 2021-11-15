using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision!");
        if (collision.gameObject.CompareTag("Enemy")) {
            Debug.Log("Enemy!");
            Destroy(collision.gameObject);
        }
    }

}
