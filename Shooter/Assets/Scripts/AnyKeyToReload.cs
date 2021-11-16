using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnyKeyToReload : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            EndGameManager.RestartGame();
        }
    }
}
