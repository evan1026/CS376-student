using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour {

    public GameObject EndGameText;

    private static EndGameManager inst;

    // Start is called before the first frame update
    void Start() {
        inst = this;
    }

    public static void EndGame() {
        inst.EndGamePrivate();
    }

    private void EndGamePrivate() {
        if (EndGameText != null) {
            EndGameText.SetActive(true);
        }
    }

    public static void RestartGame() {
        inst.RestartGamePrivate();
    }

    private void RestartGamePrivate() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
