using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour {

    private TMP_Text text;
    private int score;

    private static Scoring inst;

    void Start() {
        inst = this;
        text = GetComponent<TMP_Text>();
        SetScore(0);
    }

    public void setScore(int score) {
        this.score = score;
        updateText();
    }

    public void addScore(int score) {
        SetScore(this.score + score);
    }

    public void subtractScore(int score) {
        AddScore(-score);
    }

    public static void SetScore(int score) {
        inst.setScore(score);
    }

    public static void AddScore(int score) {
        inst.addScore(score);
    }

    public static void SubtractScore(int score) {
        inst.subtractScore(score);
    }

    private void updateText() {
        text.text = "Score: " + score;
    }
}
