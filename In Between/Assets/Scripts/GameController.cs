using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)/* || CrossPlatformInputManager.GetButtonDown("quit")*/)
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R)/* || CrossPlatformInputManager.GetButtonDown("reset")*/)
        {
            SceneManager.LoadScene("Main");
        }
    }
}