using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

    public Text gameOver;

    public void Update() {
        if (Input.anyKeyDown) {
            Exit();
        }
    }

    public void Enter() {
        Time.timeScale = 0;
        if (BrickController.totalBricks == 0) {
            gameOver.text = "YOU WIN!";
        } else {
            gameOver.text = "GAME OVER";
        }
        gameObject.SetActive(true);
    }

    public void Exit() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
