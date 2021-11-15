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
    }

    public void SetScore(int score) {
        this.score = score;
        updateText();
    }

    public void AddScore(int score) {
        SetScore(this.score + score);
    }

    public void SubtractScore(int score) {
        AddScore(-score);
    }

    private void updateText() {
        text.text = "Score: " + score;
    }
}
