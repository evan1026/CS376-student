using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class ScoreManager : MonoBehaviour {
    private static int score;
    private static Text textObject;

    public Text ScoreTextObject;

    public void Start() {
        textObject = ScoreTextObject;
        AddScore(0);  // Makes sure that when we reload the level the text object gets updated
    }

    public static void AddScore(int val) {
        score += val;
        textObject.text = "Score: " + score;
    }

    public static void BrickDowngraded() {
        AddScore(50);
    }

    public static void BrickDestroyed() {
        AddScore(100);
    }

    public static void LevelCleared() {
        AddScore(100000);
    }
}
