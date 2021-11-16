using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour {

    private Player player;

    private void Start() {
        player = FindObjectOfType<Player>();
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
            if (player != null) {
                player.BlowUp(null);
            }
        } else if (collision.gameObject.CompareTag("Star")) {
            Destroy(collision.gameObject);
        }
    }

}
