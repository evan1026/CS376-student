using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class ScoreManager : MonoBehaviour {
    private static int score;
    private static Text textObject;
    private static Text finalTextObject;

    public Text ScoreTextObject;
    public Text FinalScoreTextObject;

    public void Start() {
        score = 0;
        textObject = ScoreTextObject;
        finalTextObject = FinalScoreTextObject;
    }

    public static void AddScore(int val) {
        score += val;
        textObject.text = "Score: " + score;
        finalTextObject.text = "Final Score: " + score;
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
