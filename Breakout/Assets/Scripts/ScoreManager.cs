using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ScoreManager {
    private static int score;

    public static void AddScore(int val) {
        score += val;
        Debug.Log("Score: " + score);
    }

    public static void BrickDowngraded() {
        AddScore(50);
    }

    public static void BrickDestroyed() {
        AddScore(100);
    }

    public static void LevelCleared() {
        AddScore(10000);
    }
}
