using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

    static Dictionary<int, Color> levelColors = null;

    public int Level = 1;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start() {
        if (levelColors == null) {
            levelColors = new Dictionary<int, Color>();
            levelColors.Add(1, Color.red);
            levelColors.Add(2, new Color(1.0f, 0.5f, 0.0f, 1.0f));  // Orange
            levelColors.Add(3, Color.yellow);
            levelColors.Add(4, Color.green);
            levelColors.Add(5, Color.blue);
            levelColors.Add(6, new Color(0.8f, 0.0f,  1.0f, 1.0f));  // Purple
            levelColors.Add(7, new Color(1.0f, 0.5f,  1.0f, 1.0f));  // Pink
            levelColors.Add(8, new Color(0.5f, 0.25f, 0.0f, 1.0f));  // Brown
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        updateLevel(Level);
    }

    private void updateLevel(int level) {
        Level = level;
        spriteRenderer.color = levelColors[Level];
    }

    private void hit() {
        if (Level > 1) {
            updateLevel(Level - 1);
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            hit();
        }
    }
}
