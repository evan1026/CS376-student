using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public void Update() {
        if (Input.anyKeyDown) {
            Exit();
        }
    }

    public void Enter() {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void Exit() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
